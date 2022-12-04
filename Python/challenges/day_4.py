def check_for_containment_pairs(pairs: list, range_overlap=False):
    pair1 = pairs[0].split("-")
    pair2 = pairs[1].split("-")
    if int(pair1[0]) == int(pair2[0]) or int(pair1[1]) == int(pair2[1]):
        return True  
    if int(pair1[0]) <= int(pair2[0]) and int(pair1[1]) >= int(pair2[1]):
        return True    
    if int(pair2[0]) <= int(pair1[0]) and int(pair2[1]) >= int(pair1[1]):
        return True    
    if range_overlap:
        if int(pair1[0]) <= int(pair2[0]) and int(pair1[1]) >= int(pair2[0]):
            return True  
        if int(pair2[0]) <= int(pair1[0]) and int(pair2[1]) >= int(pair1[0]):
            return True  
    return False
    
def a(input):
    counter = 0
    for id_number in input:
        entry = id_number.split(",")
        if check_for_containment_pairs(entry):
            counter += 1
    return counter

def b(input):
    counter = 0
    for id_number in input:
        entry = id_number.split(",")
        if check_for_containment_pairs(entry, True):
            counter += 1
    return counter
