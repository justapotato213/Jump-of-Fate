
from PIL import Image
import random
from itertools import permutations
import itertools


def get_concat_h(im1, im2):
    """
    Function to combine images horizontally

    Parameters
    ----------
    im1 : first image to combine
    im2 : second image to combine

    Returns
    --------
    Combined image of the two
    """
    dst = Image.new('RGB', (im1.width + im2.width, im1.height))
    dst.paste(im1, (0, 0))
    dst.paste(im2, (im1.width, 0))
    return dst


def get_concat_v(im1, im2):
    """
    Function to combine images vertically

    Parameters
    ----------
    im1 : first image to combine
    im2 : second image to combine

    Returns
    --------
    Combined image of the two
    """
    dst = Image.new('RGB', (im1.width, im1.height + im2.height))
    dst.paste(im1, (0, 0))
    dst.paste(im2, (0, im1.height))
    return dst


height = int(input("Enter the number of slices as the height of the level: "))
length = int(input("Enter the number of slices as the length of the level: "))
num = int(input("Enter the number of slices you have: "))

images = []

# Store slices in a list
for i in range(1, num + 1):
    name = "im" + str(i)
    im = Image.open('./Input_Images/' + name + '.png')
    images.append(im)

start = Image.open('./Input_Images/start.png')
sky = Image.open('./Input_Images/sky.png')

# perm = list(permutations(images))
# perm = list(map(list, perm))
perm = [p for p in itertools.product(images, repeat=len(images))]
print(perm)
for i in range(len(perm)):
    for j in range(1, len(images) + 1):
        image = perm[i][j-1]
        if j == 1:
            level = get_concat_h(start, image)
        else:
            level = get_concat_h(level, image)
    level.save('./Perm/level' + str(i) + '.png')


# Generates Random Level

# for k in range(len(perm)):
#     slices = []
#     for l in range(1, length+2):
#         if l == 1:
#             slices.append(get_concat_v(sky, start))
#             continue
#         image = images[k[l]]
#         print(images)
#         slices.append(get_concat_v(sky, image))
#     print(slices)
#     # Combine the vertical slices horizontally
#     for i in range(len(slices)):
#         if i == len(slices) - 1:
#             break
#         if i == 0:
#             level = get_concat_h(slices[i], slices[i+1])
#             continue
#         level = get_concat_h(level, slices[i+1])
#
#     level.save('./Level_Images/level' + str(i) + '.png')



    #
    #         level = get_concat_h(level, image)
    # level.save('./Perm/level' + str(i) + '.png')


# Generates Random Level

# for k in range(len(perm)):
#     slices = []
#     for l in range(1, length+2):
#         if l == 1:
#             slices.append(get_concat_v(sky, start))
#             continue
#         image = images[k[l]]
#         print(images)
#         slices.append(get_concat_v(sky, image))
#     print(slices)
#     # Combine the vertical slices horizontally
#     for i in range(len(slices)):
#         if i == len(slices) - 1:
#             break
#         if i == 0:
#             level = get_concat_h(slices[i], slices[i+1])
#             continue
#         level = get_concat_h(level, slices[i+1])
#
#     level.save('./Level_Images/level' + str(i) + '.png')



