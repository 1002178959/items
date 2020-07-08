import pygame
import math


pygame.init()

x = []
y = []
for i in range(0, 15):
    x.append(28 + i * 40)
    y.append(28 + i * 40)

class Storn_Black(pygame.sprite.Sprite):
    
    def __init__(self,pos):
        pygame.sprite.Sprite.__init__(self)

        self.image = pygame.image.load('image/storn_black.png')\
                    .convert_alpha()
        self.rect = self.image.get_rect()
        self.pos = pos

    def location(self):
        pos_x = pos_y = None
        for each in x:
            if math.fabs(each - self.pos[0]) <= 20:
                pos_x = each
        for each in y:
            if math.fabs(each - self.pos[1]) <= 20:
                pos_y = each
        return pos_x,pos_y

    def image_rect(self):
        return self.location()[0] - self.rect.width//2, self.location()[1] - self.rect.height//2


class Storn_White(pygame.sprite.Sprite):
    def __init__(self,pos):
        pygame.sprite.Sprite.__init__(self)

        self.image = pygame.image.load('image/storn_white.png')\
                    .convert_alpha()
        self.rect = self.image.get_rect()
        self.pos = pos

    def location(self):
        global x
        global y
        pos_x = 0
        pos_y = 0
        for each in x:
            if math.fabs(each - int(self.pos[0])) <= 20:
                pos_x = each
        for each in y:
            if math.fabs(each - int(self.pos[1])) <= 20:
                pos_y = each
        return pos_x,pos_y

    def image_rect(self):
        return self.location()[0] - self.rect.width//2, self.location()[1] - self.rect.height//2
