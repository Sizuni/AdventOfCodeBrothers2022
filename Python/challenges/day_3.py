def create_item_dict():
    item_dict = {}
    for i in range(26):
        letter = chr(i + ord("a"))
        item_dict[letter] = [0, i + 1]
    for j in range(26):
        letter = chr(j + ord("A"))
        item_dict[letter] = [0, j + 1 + 26]
    return item_dict

def get_common_item(rucksack):
    comp_length = int(len(rucksack))
    comp1 = rucksack[0:int(comp_length/2):1]
    comp2 = rucksack[int(comp_length/2):comp_length:1]
    for i in range(int(comp_length/2)):
        if comp1[i] in comp2:
            return comp1[i]
        if comp2[i] in comp1:
            return comp2[i]

def get_priority_sum(common_items: dict):
    sum = 0
    for item in common_items.values():
        sum += item[0] * item[1]
    return sum

def a(input):
    common_items = create_item_dict()
    for rucksack in input:
        common_items[get_common_item(rucksack)][0] += 1
    return get_priority_sum(common_items)

def b(input):
    pass
