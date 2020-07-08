# _*_ encoding:utf-8 _*_
import pygame
from pygame.locals import *
import sys
import math
import storn
from socket import *
import select

pygame.init()

BLACK = (0, 0, 0)
WHITE = (255, 255, 255)

bg_size = 615, 615

# 棋盘
x = []
y = []
for i in range(0, 15):
    x.append(28 + i * 40)
    y.append(28 + i * 40)

# 记录棋盘每个坐标的属性，没有棋子为0，白棋为1，黑棋为2
map_chess = {}


# 输赢
font1 = pygame.font.Font('font/12345.TTF', 35)
win_text = font1.render(u"黑棋赢!!!", True, WHITE)
win_text_rect = win_text.get_rect()
win_text_rect.left, win_text_rect.top = (bg_size[0] - win_text_rect.width) // 2, \
                                        (bg_size[1] - win_text_rect.height) // 2
lose_text = font1.render(u"白棋赢", True, WHITE)
lose_text_rect = lose_text.get_rect()
lose_text_rect.left, lose_text_rect.top = (bg_size[0] - lose_text_rect.width) // 2, \
                                          (bg_size[1] - lose_text_rect.height) // 2
play_text = font1.render(u"再玩一局", True, WHITE)
play_text_rect = play_text.get_rect()
menu_text = font1.render(u'主菜单', True, WHITE)
menu_text_rect = menu_text.get_rect()

# 登入选项
text1 = font1.render(u"局域网对战", True, WHITE)
text1_rect = text1.get_rect()
text1_rect.left, text1_rect.top = (bg_size[0] - text1_rect.width) // 2, \
                                  (bg_size[1] - text1_rect.height) // 2 - 100
text2 = font1.render(u'人机对战', True, WHITE)
text2_rect = text2.get_rect()
text2_rect.left, text2_rect.top = (bg_size[0] - text1_rect.width) // 2, \
                                  (bg_size[1] - text1_rect.height) // 2
text3 = font1.render(u'声音：  开', True, WHITE)
text3_rect = text3.get_rect()
text3_rect.left, text3_rect.top = (bg_size[0] - text3_rect.width) // 2, \
                                  (bg_size[1] - text3_rect.height) // 2 + 100
text4 = font1.render(u'声音：  关', True, WHITE)
text4_rect = text4.get_rect()
text4_rect.left, text4_rect.top = (bg_size[0] - text4_rect.width) // 2, \
                                  (bg_size[1] - text4_rect.height) // 2 + 100
text5 = font1.render(u'等待连接', True, WHITE)
text5_rect = text4.get_rect()
text5_rect.left, text5_rect.top = (bg_size[0] - text5_rect.width) // 2, \
                                  (bg_size[1] - text5_rect.height) // 2
text6 = font1.render(u'对方表示你很菜\n并断开了连接', True, WHITE)
text6_rect = text6.get_rect()
text6_rect.left, text6_rect.top = (bg_size[0] - text6_rect.width) // 2, \
                                  (bg_size[1] - text6_rect.height) // 2
text7 = font1.render(u'对方再次向你发起挑战', True, WHITE)
text7_rect = text7.get_rect()
text7_rect.left, text7_rect.top = (bg_size[0] - text7_rect.width) // 2, \
                                  (bg_size[1] - text7_rect.height) // 2
text8 = font1.render(u'接受挑战         不接受挑战', True, WHITE)
text8_rect = text8.get_rect()
text8_rect.left, text8_rect.top = (bg_size[0] - text8_rect.width) // 2, \
                                  (bg_size[1] - text8_rect.height) // 2 + 100

# TCP服务
HOST = ''  # 地址
#
POST = 21578  # 端口
BUFSIZ = 2048
ADDR = (HOST, POST)
tcpsersock = socket(AF_INET, SOCK_STREAM)
tcpsersock.bind(ADDR)
tcpsersock.listen(1)

inputs = [tcpsersock]

# 判断是否有子
def is_empty(me, targert):
    global map_chess
    a = False
    if map_chess[str(me[0]) + '|' + str(me[1])]:
        a = True
    return a



# 判断是否有五子连线
def is_win(targert):
    for each in targert:
        (a,b) = each.location()

        # x轴方向
        num_x = 0
        c = a - 40
        d = a + 40
        while c > 0:
            isbreak = True
            for i in targert:
                if i.location() == (c, b):
                    num_x += 1
                    isbreak = False
            if not isbreak:
                c -= 40
            else:
                break
        while d < 615:
            isbreak = True
            for i in targert:
                if i.location() == (d, b):
                    num_x += 1
                    isbreak = False
            if not isbreak:
                d += 40
            else:
                break
        num_x += 1

        # y轴方向
        num_y = 0
        e = b - 40
        f = b + 40
        while e > 0:
            isbreak = True
            for i in targert:
                if i.location() == (a, e):
                    num_y += 1
                    isbreak = False
            if not isbreak:
                e -= 40
            else:
                break
        while f < 615:
            isbreak = True
            for i in targert:
                if i.location() == (a, f):
                    num_y += 1
                    isbreak = False
            if not isbreak:
                f += 40
            else:
                break
        num_y += 1

        # 西北，东南方向
        num_en = 0
        c1 = a - 40
        c2 = b - 40
        c3 = a + 40
        c4 = b + 40
        while c1 > 0 and c2 > 0:
            isbreak = True
            for i in targert:
                if i.location() == (c1, c2):
                    num_en += 1
                    isbreak = False
            if not isbreak:
                c1 -= 40
                c2 -= 40
            else:
                break
        while c3 < 615 and c4 < 615:
            isbreak = True
            for i in targert:
                isbreak = True
                if i.location() == (c3, c4):
                    num_en += 1
                    isbreak = False
            if not isbreak:
                c3 += 40
                c4 += 40
            else:
                break
        num_en += 1

        # 东北，西南方向
        num_wn = 0
        c5 = a + 40
        c6 = b - 40
        c7 = a - 40
        c8 = b + 40
        while c5 < 615 and c6 > 0:
            isbreak = True
            for i in targert:
                if i.location() == (c5, c6):
                    num_wn += 1
                    isbreak = False
            if not isbreak:
                c5 += 40
                c6 -= 40
            else:
                break
        while c7 > 0 and c8 < 615:
            isbreak = True
            for i in targert:
                isbreak = True
                if i.location() == (c7, c8):
                    num_wn += 1
                    isbreak = False
            if not isbreak:
                c7 -= 40
                c8 += 40
            else:
                break
        num_wn += 1
        if num_x >= 5 or num_y >= 5 or num_en >= 5 or num_wn >= 5:
            return True
    return False


# 判断每个点的价值
def point_value(pos, white_chesses, black_chesses, identify1, identify2):
    value = 0
    for i in range(1,9):
        # *1111_ 活四
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == 0:
            value += 40000
        # *11112 死四1
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == identify2:
            value += 30000
        # 1*111 死四2
        if get_point(pos, i, -1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1:
            value += 30000
        # 11*11 死四3
        if get_point(pos, i, -2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, -1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1:
            value += 30000
        # *111_ 活三1
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == 0:
            value += 20000
        # *1_11_ 活三2
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == 0:
            value += 20000
        # *1112 死三1
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify2:
            value += 15000
        # _1_112 死三2
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == identify2:
            value += 15000
        # _11_12 死三3
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == identify2:
            value += 15000
        # 1__11 死三4
        if get_point(pos, i, -1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1:
            value += 15000
        # 1_1_1 死三5
        if get_point(pos, i, -1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1:
            value += 15000
        # 2_111_2 死三6
        if get_point(pos, i, -1, white_chesses, black_chesses) == identify2 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 5, white_chesses, black_chesses) == identify2:
            value += 15000
        # __11__ 活二1
        if get_point(pos, i, -1, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == 0:
            value += 1000
        # _1_1_ 活二2
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == 0:
            value += 1000
        # *1___
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 3, white_chesses, black_chesses) == 0 and \
            get_point(pos, i, 4, white_chesses, black_chesses) == 0:
            value += 50
        # *1_
        if get_point(pos, i, 1, white_chesses, black_chesses) == identify1 and \
            get_point(pos, i, 2, white_chesses, black_chesses) == 0:
            value += 20
    return value

# 电脑选取落子的位置
def ai(white_chesses, black_chesses, chesses):
    value = max1 = max2 = 0
    pos1 = pos2 = ()
    # 进攻时
    for i in range(0,15):
        row = 28 + i * 40
        for j in range(0,15):
            col = 28 + j * 40
            pos = (row,col)
            if is_empty(pos, chesses):
                continue
            value = point_value(pos, white_chesses, black_chesses, 1, 2)
            if value > max1:
                max1 = value
                pos1 = (row,col)

    # 防守时
    for i in range(0,15):
        for j in range(0,15):
            row = 28 + i * 40
            col = 28 + j * 40
            if is_empty((row,col), chesses):
                continue
            value = point_value((row,col), white_chesses, black_chesses, 2, 1)
            if value > max2:
                max2 = value
                pos2 = (row,col)
    if max1 > max2:
        return pos1
    else:
        return pos2


# 获取当前坐标的属性，返回1代表白棋，返回2代表黑棋，返回3代表没有棋
def get_point(pos, src, offset, white_chesses, black_chesses):
    # 8个方向
    global map_chess
    directions = [[0,1],[1,1],[1,0],[1,-1],[0,-1],[-1,-1],[-1,0],[-1,1]]
    x1,y1 = pos
    x1 = x1 + directions[src-1][0] * offset * 40
    y1 = y1 + directions[src-1][1] * offset * 40
    if x1 > 588 or y1 > 588 or x1 < 28 or y1 < 28:
        return 5
    else:
        return map_chess[str(x1) + '|' + str(y1)]

# 初始化棋盘
def init():
    global map_chess
    for i in x:
        for j in y:
            map_chess[str(i) + '|' + str(j)] = 0


def main():

    clock = pygame.time.Clock()

    screen = pygame.display.set_mode(bg_size)
    pygame.display.set_caption('五子棋')
    bg_image = pygame.image.load('image/bg.png').convert_alpha()  # 背景图片

    # 背景音乐
    bg_sound = pygame.mixer.music.load('sound/bg_music.mp3')
    pygame.mixer.music.set_volume(0.5)
    pygame.mixer.music.play(-1)

    # 棋子
    white_chesses = []
    black_chesses = []
    chesses = []

    # 标志轮到哪方下棋
    is_play = False

    # 标志是否连接
    is_link = False

    # 标志是否结束游戏
    is_end = False

    # 标志人与人
    is_people = False

    # 标志人与电脑
    is_ai = False

    # 标志赢方
    white_win = False
    black_win = False

    # 标志是否做出选择
    is_choise = False

    # 标志是否关闭声音
    is_have_sound = True

    # 标志是否再来一局
    is_playagain = False

    # 对面是否发来重新开始的消息
    is_recieve1 = False

    # 对面拒绝了重新开始
    is_recieve2 = False

    # 重新开始一局
    is_playagain = False

    running = True

    init()

    while running:

        screen.blit(bg_image, (0, 0))

        # 绘制选项
        if not is_choise:
            screen.blit(text1, text1_rect)
            screen.blit(text2, text2_rect)
            if not is_have_sound:
                screen.blit(text4, text4_rect)
            else:
                screen.blit(text3, text3_rect)
        else:
            if is_people:
                if not is_link and not is_recieve2:
                    screen.blit(text5, text5_rect)

        # 接收cli的消息
        if is_people:
            rs, ws, es = select.select(inputs, [], [], 0)
            for r in rs:
                if r is tcpsersock:
                    tcpclisock, addr = tcpsersock.accept()
                    inputs.append(tcpclisock)
                    is_link = True
                    print('connenct')
                else:
                    try:
                        data = r.recv(BUFSIZ)
                        print(data.decode('utf8'))
                        if data.decode('utf8') == 'again':
                            is_recieve1 = True
                        if data.decode('utf8') == 'yes':
                            is_playagain = True
                            is_play = False
                        if data.decode('utf8') == 'no':
                            is_recieve2 = True
                            is_link = False
                        if data.decode('utf8') == 'regret':
                            chesses.pop()
                            chesses.pop()
                            map_chess[
                                str(white_chesses[-1].location()[0]) + '|' + str(white_chesses[-1].location()[1])] = 0
                            map_chess[
                                str(black_chesses[-1].location()[0]) + '|' + str(black_chesses[-1].location()[1])] = 0
                            white_chesses.pop()
                            black_chesses.pop()
                        disconnected = not data
                    except error:
                        disconnected = True
                        is_link = False
                    if disconnected:
                        inputs.remove(r)
                    else:
                        if not is_play and not is_end:
                            me = storn.Storn_White(eval(data))
                            if not is_empty(me.location(), chesses):
                                white_chesses.append(me)
                                chesses.append(me)
                                map_chess[str(me.location()[0]) + '|' + str(me.location()[1])] = 1
                                is_play = True
                            else:
                                del(me)

        for event in pygame.event.get():
            if event.type == QUIT:
                if is_link:
                    tcpclisock.close()
                if is_people:
                    tcpsersock.close()
                pygame.quit()
                sys.exit()

            if event.type == pygame.KEYDOWN and event.key == pygame.K_BACKSPACE:
                if len(chesses) >= 2 and len(white_chesses) >= 1 and len(black_chesses) >= 1 \
                        and not is_end:
                    chesses.pop()
                    chesses.pop()
                    map_chess[str(white_chesses[-1].location()[0]) + '|' + str(white_chesses[-1].location()[1])] = 0
                    map_chess[str(black_chesses[-1].location()[0]) + '|' + str(black_chesses[-1].location()[1])] = 0
                    white_chesses.pop()
                    black_chesses.pop()
                    if is_people and not is_end:
                        tcpclisock.send('regret'.encode('utf8'))

            if event.type == MOUSEBUTTONDOWN:
                if event.button == 1:

                    if is_choise:
                        if is_play and not is_recieve1 and not is_end:
                            pos = pygame.mouse.get_pos()
                            me = storn.Storn_Black(pos)
                            if not is_empty(me.location(), chesses):
                                black_chesses.append(me)
                                chesses.append(me)
                                map_chess[str(me.location()[0]) + '|' + str(me.location()[1])] = 2
                                if is_people:
                                    tcpclisock.send(str(pos).encode('utf8'))
                                is_play = False
                            else:
                                del (me)
                    else:
                        pos = pygame.mouse.get_pos()
                        if text1_rect.left <= pos[0] <= text1_rect.left + 170 and \
                                                text1_rect.top <= pos[1] <= text1_rect.top + 30:
                            is_choise = True
                            is_people = True
                        if text1_rect.left <= pos[0] <= text1_rect.left + 170 and \
                                                        text1_rect.top + 100 <= pos[1] <= text1_rect.top + 130:
                            is_choise = True
                            is_ai = True
                            is_play = True
                        if text1_rect.left <= pos[0] <= text1_rect.left + 160 and \
                                                        text1_rect.top + 200 <= pos[1] <= text1_rect.top + 230:
                            is_have_sound = not is_have_sound
                            if not is_have_sound:

                                pygame.mixer.stop()
                                pygame.mixer.music.stop()
                            else:
                                pygame.mixer.music.play()

                    if is_end:
                        if not is_recieve1 and not is_recieve2:
                            pos = pygame.mouse.get_pos()
                            if win_text_rect.left < pos[0] < win_text_rect.right and \
                                                    win_text_rect.top < pos[1] < win_text_rect.top + 30:
                                if is_people:
                                    tcpclisock.send('again'.encode('utf8'))
                                if is_ai:
                                    is_playagain = True
                                    is_play = True
                                    is_end = False
                                    init()

                            if win_text_rect.left < pos[0] < win_text_rect.right - 50 and \
                                                            win_text_rect.top + 50 < pos[1] < win_text_rect.top + 120:
                                is_people = False
                                is_choise = False
                                if is_link:
                                    is_link = False
                                    tcpclisock.send('no'.encode('utf8'))
                                main()




                    if is_recieve2:
                        pos = pygame.mouse.get_pos()
                        if text6_rect.left + 150 < pos[0] < text6_rect.left + 250 and \
                                                        text6_rect.top + 70 < pos[1] < text6_rect.top + 190:

                            main()
                            is_choise = False

                    if is_recieve1:
                        pos = pygame.mouse.get_pos()
                        if text8_rect.left < pos[0] < text8_rect.left + 150 and \
                                                        text8_rect.top < pos[1] < text8_rect.top + 120:
                            tcpclisock.send('yes'.encode('utf8'))
                            is_recieve1 = False
                            is_playagain = True
                            is_play = False
                            is_end = False
                        if text8_rect.left + 190 < pos[0] < text8_rect.left + 330 and \
                                                        text8_rect.top < pos[1] < text8_rect.top + 120:
                            tcpclisock.send('no'.encode('utf8'))
                            main()
        # 电脑落子
        if is_ai and not is_play:
            me = storn.Storn_White(ai(white_chesses, black_chesses, chesses))
            white_chesses.append(me)
            chesses.append(me)
            print(len(white_chesses))
            print(len(black_chesses))
            map_chess[str(me.location()[0]) + '|' + str(me.location()[1])] = 1
            is_play = True

        # 绘制棋盘
        if is_choise:
            if chesses:
                for i in chesses:
                    screen.blit(i.image, i.image_rect())

        # 判断输赢
        if not is_end and is_win(black_chesses):
            is_end = True
            black_win = True

        if not is_end and is_win(white_chesses):
            is_end = True
            white_win = True

        if black_win and not is_recieve1 and is_end and not is_recieve2:
            screen.blit(win_text, (win_text_rect.left, win_text_rect.top - 80))
            screen.blit(play_text, win_text_rect)
            screen.blit(menu_text, (win_text_rect.left, win_text_rect.top + 80))

        if white_win and not is_recieve1 and is_end and not is_recieve2:
            screen.blit(lose_text, (win_text_rect.left, win_text_rect.top - 80))
            screen.blit(play_text, win_text_rect)
            screen.blit(menu_text, (win_text_rect.left, win_text_rect.top + 80))

        if is_recieve1:
            screen.blit(text7, text7_rect)
            screen.blit(text8, text8_rect)

        if is_recieve2:
            screen.blit(text6, text6_rect)
            screen.blit(menu_text, (text6_rect.left + 150,text5_rect.top + 70))

        if is_playagain:
            white_chesses = []
            black_chesses = []
            chesses = []
            white_win = False
            black_win = False
            is_end = False
            is_playagain = False

        pygame.display.flip()

        clock.tick(60)


if __name__ == '__main__':
    main()
