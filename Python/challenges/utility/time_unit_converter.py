class TimeConverter():
    def __init__(self):
        self.units = ["us", "ms", "s"]
        self.conversions = [1 ,1/1000 ,1/1000000]
        self.round = [1, 3, 3]
        
    def convert_time(self, time):
        index = 0
        time = int(time * 1000000)
        if len(str(round(time, 0))) <= 3:
            index = 0
        elif len(str(round(time, 0))) < 6:
            index = 1
        elif len(str(round(time, 0))) < 9:
            index = 2
        return "{time} {metric}".format(time=round(time * self.conversions[index], self.round[index]), metric=self.units[index])
