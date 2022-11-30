from challenges.utility.file_reader import get_array_input
from challenges.utility.string_to_module import str_to_module

CURRENT_DAY = 1

def main():
    module = str_to_module(CURRENT_DAY)
    input = get_array_input(CURRENT_DAY)

    module.a(input)
    module.b(input)

if __name__ == "__main__":
    main()
