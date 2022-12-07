import re

def prepare_initial_stacks(input: list):
    amount_of_stacks = int(round(len(input[0]) / 4, 0))
    stacks = []
    for i in range(amount_of_stacks):
        stacks.append([])
    counter = 0
    line = input[0]

    # count how tall the highest tower is
    while line != "":
        counter += 1
        line = input[counter]
    counter -= 1
    
    # reads containers from bottom to top, saves them into stack
    for i in range(counter):
        row = input[counter - (i + 1)]
        for j in range(amount_of_stacks):
            value = row[(j + 1) * 4 - 3]
            if value != " ":
                stacks[j].append(value)
    
    return stacks, input[counter + 2:]
    
def move_containers(stacks, move, crate_mover_9001=False):
    # RegEx for extracting digits
    steps = re.findall(r'\d+', move)
    amount = int(steps[0])
    src = int(steps[1]) - 1
    dst = int(steps[2]) - 1
    
    if not crate_mover_9001:
        for i in range(amount):
            container = stacks[src].pop()
            stacks[dst].append(container)
    else:
        containers = []
        for i in range(amount):
            containers.append(stacks[src].pop())
        for j in range(amount):
            stacks[dst].append(containers.pop())

    return stacks

def get_top_containers(stacks):
    top_crates = ""
    for stack in stacks:
        top_crates += stack.top()
    return top_crates

def a(input):
    stacks, input = prepare_initial_stacks(input)
    for move in input:
        stacks = move_containers(stacks, move)
    return get_top_containers(stacks)

def b(input):
    stacks, input = prepare_initial_stacks(input)
    for move in input:
        stacks = move_containers(stacks, move, True)
    return get_top_containers(stacks)
