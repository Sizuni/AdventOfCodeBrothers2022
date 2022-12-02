def get_result(round):
    moves = round.split(" ")
    opponent = moves[0]
    you = moves[1]
    if opponent == "A":
        if you == "X":
            return 3 + 1
        elif you == "Y":
            return 6 + 2
        else:
            return 0 + 3
    elif opponent == "B":
        if you == "X":
            return 0 + 1
        elif you == "Y":
            return 3 + 2
        else:
            return 6 + 3
    else:
        if you == "X":
            return 6 + 1
        elif you == "Y":
            return 0 + 2
        else:
            return 3 + 3


def a(input):
    points = 0
    for round in input:
        points += get_result(round)
    return points

def b(input):
    pass
