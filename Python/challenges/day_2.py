def get_result(round, strategy=False):
    score_matrix = [3, 6, 0]
    moves = round.split(" ")
    opponent = int(ord(moves[0]) - 65)
    you = int(ord(moves[1]) - 88)
    if not strategy:
        return (score_matrix[3 - opponent:] + score_matrix[:3 - opponent])[you] + you + 1
    else:
        predict_move_matrix = [0, 1, 2, 0, 1, 2]
        you = predict_move_matrix[opponent - 1 + you]
        return (score_matrix[3 - opponent:] + score_matrix[:3 - opponent])[you] + you + 1

def a(input):
    points = 0
    for round in input:
        points += get_result(round)
    return points

def b(input):
    points = 0
    for round in input:
        points += get_result(round, True)
    return points
