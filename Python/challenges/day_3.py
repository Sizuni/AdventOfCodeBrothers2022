def create_item_dict():
    item_dict = {}
    for i in range(26):
        letter = chr(i + ord("a"))
        item_dict[letter] = [0, i + 1]
    for j in range(26):
        letter = chr(j + ord("A"))
        item_dict[letter] = [0, j + 1 + 26]
    return item_dict
        
def get_common_item(comps: list):
    comp1 = comps.pop()
    for i in range(len(comp1)):
        item_found_in_all = True
        for comp in comps:
            if comp1[i] not in comp:
                item_found_in_all = False
        if item_found_in_all:
            return comp1[i]

def get_priority_sum(common_items: dict):
    sum = 0
    for item in common_items.values():
        sum += item[0] * item[1]
    return sum

def a(input):
    common_items = create_item_dict()
    for rucksack in input:
        comps = []
        comp_length = int(len(rucksack))
        comps.append(rucksack[0:int(comp_length/2):1])
        comps.append(rucksack[int(comp_length/2):comp_length:1])
        common_items[get_common_item(comps)][0] += 1
    return get_priority_sum(common_items)

def b(input):
    common_items = create_item_dict()
    for i in range(int(len(input) / 3)):
        comps = []
        comps = input[i * 3:(i + 1) * 3]
        common_items[get_common_item(comps)][0] += 1
    return get_priority_sum(common_items)
