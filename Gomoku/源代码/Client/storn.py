import pygame  # Python第三方游戏库
import math  # 标准库

pygame.init()  # 初始化所有的 Py game 模块


# 黑棋类
class Storn_Black(pygame.sprite.Sprite):

    def __init__(self, pos):
        pygame.sprite.Sprite.__init__(self)  # 父类调用

        self.image = pygame.image.load('image/storn_black.png') \
            .convert_alpha()  # 可以转换格式，提高 blit 的速度，实现透明效果
        self.rect = self.image.get_rect()
        self.pos = pos

    def location(self):
        x = []
        y = []
        pos_x = pos_y = None
        for i in range(0, 15):
            x.append(28 + i * 40)
        for i in range(0, 15):
            y.append(28 + i * 40)
        # 定格棋子坐标
        for each in x:
            if math.fabs(each - self.pos[0]) <= 20:
                pos_x = each
        for each in y:
            if math.fabs(each - self.pos[1]) <= 20:
                pos_y = each
        return pos_x, pos_y

    def image_rect(self):
        return self.location()[0] - self.rect.width // 2, self.location()[1] - self.rect.height // 2


class Storn_White(pygame.sprite.Sprite):
    def __init__(self, pos):
        pygame.sprite.Sprite.__init__(self)

        self.image = pygame.image.load('image/storn_white.png') \
            .convert_alpha()
        self.rect = self.image.get_rect()
        self.pos = pos

    def location(self):
        x = []
        y = []
        pos_x = pos_y = None
        for i in range(0, 15):
            x.append(28 + i * 40)
        for i in range(0, 15):
            y.append(28 + i * 40)
        for each in x:
            if math.fabs(each - self.pos[0]) <= 20:
                pos_x = each
        for each in y:
            if math.fabs(each - self.pos[1]) <= 20:
                pos_y = each
        return pos_x, pos_y

    def image_rect(self):
        return self.location()[0] - self.rect.width // 2, self.location()[1] - self.rect.height // 2
