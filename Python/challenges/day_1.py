def a(input):
    highest = 0
    sum = 0
    for calories in input:
        if calories == '':
            if sum > highest:
                highest = sum
            sum = 0
        else:
            sum += int(calories)
    return highest

def b(input):
    highest = [0,0,0]
    sum = 0
    for calories in input:
        if calories == '':
            highest.append(sum)
            highest.sort(reverse=True)
            highest.pop()
            sum = 0
        else:
            sum += int(calories)
    return highest[0] + highest[1] + highest[2]
