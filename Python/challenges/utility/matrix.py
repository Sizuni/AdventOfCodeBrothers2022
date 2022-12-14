class Matrix():
    def __init__(self):
        self.matrix = []
    
    def set_size(self, size: int):
        self.matrix = []
        for i in range(size):
            self.matrix.append([])
    
    def get_size(self):
        return len(self.matrix)
        
    def insert_row(self, values: list):
        row = []
        for value in values:
            row.append(value)
        self.matrix.append(row)
        
    def insert_row_numbers(self, values: list):
        row = []
        for value in values:
            row.append(int(value))
        self.matrix.append(row)
    
    def get_row(self, index: int):
        return self.matrix[index]

    def get_column(self, index: int):
        column = []
        for i in range(len(self.matrix)):
            column.append(self.matrix[i][index])
        return column
    
    def update_column(self, index: int, column: list):
        column_index = -1
        for row in self.matrix:
            column_index += 1
            row[index] = column[column_index]
                
    def __str__(self):
        output = ""
        for row in self.matrix:
            output += str(row) + "\n"
        output = output[0:len(output) - 1]
        return output
    