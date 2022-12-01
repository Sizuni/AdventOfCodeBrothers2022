import timeit

class Stopwatch():
    def __init__(self):
        self.timestamps = []
        
    def capture_time(self):
        self.timestamps.append(timeit.default_timer())
        
    def return_timestamps(self):
        time = []
        for i in range(len(self.timestamps) - 1):
            time.append(self.timestamps[i + 1] - self.timestamps[i])
        return time      
