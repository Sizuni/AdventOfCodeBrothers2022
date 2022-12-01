from simple_chalk import chalk
from challenges.utility.file_reader import get_array_input
from challenges.utility.string_to_module import str_to_module
from challenges.utility.stopwatch import Stopwatch

CURRENT_DAY = 1

def main():
    stopwatch = Stopwatch()
    module = str_to_module(CURRENT_DAY)
    input = get_array_input(CURRENT_DAY)

    print(chalk.yellow.bold("Day {CURRENT_DAY}".format(CURRENT_DAY=CURRENT_DAY)))
    print(chalk.green.bold("Solutions:"))
    stopwatch.capture_time()
    print(chalk.red("Part 1: ") + str(module.a(input)))
    stopwatch.capture_time()
    print(chalk.red("Part 2: ") + str(module.b(input)))
    stopwatch.capture_time()
    
    timestamps = stopwatch.return_timestamps()
    
    print(chalk.green.bold("Benchmarks:"))
    for i in range(len(timestamps)):
        print(chalk.red("Part {i}: ").format(i = i + 1) + "{time}".format(i = i + 1, time = timestamps[i]))

if __name__ == "__main__":
    main()
