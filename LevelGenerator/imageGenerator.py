import sys
from PIL import Image
import random

def get_concat_h(im1, im2):
    dst = Image.new('RGB', (im1.width + im2.width, im1.height))
    dst.paste(im1, (0, 0))
    dst.paste(im2, (im1.width, 0))
    return dst


def get_concat_v(im1, im2):
    dst = Image.new('RGB', (im1.width, im1.height + im2.height))
    dst.paste(im1, (0, 0))
    dst.paste(im2, (0, im1.height))
    return dst


height = int(input("Enter the number of slices as the height of the level: "))
length = int(input("Enter the number of slices as the length of the level: "))
num = int(input("Enter the number of slices you have: "))

images = []

# Store images in
for i in range(1, num + 1):
    name = "im" + str(i)
    im = Image.open('./Input_Images/' + name + '.png')
    images.append(im)

start = Image.open('./Input_Images/start.png')
sky = Image.open('./Input_Images/sky.png')

slices = []
for l in range(1, length+1):
    if l == 1:
        slices.append(get_concat_v(sky, start))
        continue
    image = random.choice(images)
    slices.append(get_concat_v(sky, image))

for i in range(len(slices)):
    if i == len(slices) - 1:
        break
    if i == 0:
        level = get_concat_h(slices[i], slices[i+1])
        continue
    level = get_concat_h(level, slices[i+1])

level.save('./Level_Images/level2.png')


