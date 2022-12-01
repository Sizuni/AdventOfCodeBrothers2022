def get_highest_sum(emptyList: list, data):
    input = data
    highest = emptyList
    sum = 0
    for calories in input:
        if calories == '':
            highest.append(sum)
            highest.sort(reverse=True)
            highest.pop()
            sum = 0
        else:
            sum += int(calories)
    return highest

def a(input):
    highest = get_highest_sum([0], input)
    return highest[0]

def b(input):
    highest = get_highest_sum([0,0,0], input)
    return highest[0] + highest[1] + highest[2]
