def check_for_duplicates(stack):
    for i in range(len(stack) - 1):
        for j in range(len(stack) - 1):
            if stack[i - (j + 1)] == stack[i]:
                return False
    return True            

def iterate_through_packet(input, packet_length):
    stack = []
    for i in range(len(input)):
        stack.append(input[i])
        if len(stack) >= packet_length:
            if check_for_duplicates(stack):
                return i + 1
            stack.pop(0)

def a(input):
    return iterate_through_packet(input[0], 4)
    

def b(input):
    return iterate_through_packet(input[0], 14)
