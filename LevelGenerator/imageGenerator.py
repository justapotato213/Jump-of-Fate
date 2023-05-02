from PIL import Image
import random
# from itertools import permutations
# import itertools


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


def image_storage(num):
    """
    Function to store all input images

    Parameters
    ----------
    num : the number of slices

    Returns
    --------
    A list with all the slices
    """
    images = []
    # Store slices in a list
    for i in range(1, num + 1):
        name = "im" + str(i)
        im = Image.open('./Input_Images/' + name + '.png')
        images.append(im)

    return images


def randomizer(amount, length, images):
    """
    Saves the generated random levels to a folder

    Parameters
    ----------
    amount : the num of images to generate
    length : the length of each level
    images : list with all the images
    """
    for k in range(amount):
        for i in range(length):
            image = random.choice(images)
            if i == 0:
                level = get_concat_h(start, image)
            else:
                level = get_concat_h(level, image)
        level = get_concat_h(level, end)
        level.save('./Levels/level' + str(k) + '.png')
    return


def tester(amount, images):
    """
    Function to combine images vertically

    Parameters
    ----------
    amount : number of slices
    images : list with all the images
    """
    for i in range(amount):
        image = images[i]
        level = get_concat_h(start, image)
        level = get_concat_h(level, end)
        level.save('./Levels/test' + str(i) + '.png')
    return


# Change this value for getting test levels vs actual levels
test = False

start = Image.open('./Input_Images/start.png')
end = Image.open('./Input_Images/end.png')

if test is False:
    am = int(input("Enter the amount of levels to generate: "))
    size = int(input("Enter the number of slices as the length of the level: "))
    num = int(input("Enter the number of slices you have: "))
    ims = image_storage(num)
    randomizer(am, size, ims)
else:
    num = int(input("Enter the number of slices you have: "))
    ims = image_storage(num)
    tester(num, ims)

print("DONE")

# Permutations Code (OLD)

# perm = list(permutations(images))
# perm = list(map(list, perm))
# perm = [p for p in itertools.product(images, repeat=len(images))]
# print(perm)
# for i in range(len(perm)):
#     for j in range(1, len(images) + 1):
#         image = perm[i][j-1]
#         if j == 1:
#             level = get_concat_h(start, image)
#         else:
#             level = get_concat_h(level, image)
#     level.save('./Perm/level' + str(i) + '.png')


# Generates Random Level With Vertical (OLD)

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




