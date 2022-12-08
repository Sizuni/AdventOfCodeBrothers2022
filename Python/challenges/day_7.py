def find_smallest_dir_with_update_size(tree, update_size):
    smallest = None
    current_space = tree["/"]
    space_to_free = abs(70000000 - (current_space + update_size))
    for value in tree.values():
        if value > space_to_free:
            if smallest == None :
                smallest = value
            if smallest > value:
                smallest = value
    return smallest

def get_sum_dirs_under_max_size(tree, max_size):
    sum = 0
    for value in tree.values():
        if value < max_size:
            sum += value
    return sum

def count_directory_size(input):
    sum = 0
    line = input[0].split(" ")
    while line[0] != "$":
        line = input.pop(0).split(" ")
        if line[0] != "dir":
            sum += int(line[0])
        if len(input) == 0:
            break
        line = input[0].split(" ")
    return input, sum
    
def go_directory_back(directory):
    new_directory = ""
    directory = directory.split("/")
    for i in range(len(directory) - 2):
        new_directory += directory[i] + "/"
    return new_directory
    
def calculate_sum_directories(input, max_size, update_size=0):
    directory = ""
    tree = {}
    while len(input) != 0:
        line = input.pop(0).split(" ")
        if line[0] == "$":
            if line[1] == "cd":
                if line[2] == "/":
                    tree[line[2]] = 0
                    directory = line[2]
                elif line[2] == "..":
                    dir_size = tree[directory]
                    directory = go_directory_back(directory)
                    tree[directory] += dir_size
                else:
                    directory += line[2] + "/"
                    tree[directory] = 0
            elif line[1] == "ls":
                input, sum = count_directory_size(input)
                tree[directory] = sum
    while directory != "/":
        dir_size = tree[directory]
        directory = go_directory_back(directory)
        tree[directory] += dir_size
    if update_size == 0:
        return get_sum_dirs_under_max_size(tree, max_size)    
    return find_smallest_dir_with_update_size(tree, update_size)

def a(input):
    input_copy = input.copy()
    return calculate_sum_directories(input_copy, 100000)

def b(input):
    return calculate_sum_directories(input, 100000, 30000000)
