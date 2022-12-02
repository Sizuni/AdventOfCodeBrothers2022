def get_result(round):
    score_matrix = [3, 6, 0]
    moves = round.split(" ")
    opponent = int(ord(moves[0]) - 65)
    you = int(ord(moves[1]) - 88)
    return (score_matrix[3 - opponent:] + score_matrix[:3 - opponent])[you] + you + 1

def a(input):
    points = 0
    for round in input:
        points += get_result(round)
    return points

def b(input):
    pass
