import os

def get_array_input(day):
    folder = "day_" + str(day)
    directory = os.getcwd() + "\\Python\challenges\\" + folder + ".txt"
    file = open(directory)
    
    lines = file.read().splitlines()
    return lines
