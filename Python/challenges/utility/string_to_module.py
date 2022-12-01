import importlib

def str_to_module(day):
    full_module_name = "challenges.day_" + str(day)
    return importlib.import_module(full_module_name)
    