from challenges.utility.matrix import Matrix

def create_matrix(input):
    matrix = Matrix()
    for entry in input:
        matrix.insert_row_numbers(entry)
    return matrix

def count_trees(matrix: Matrix):
    visible_tree_count = 0
    # create new matrix to keep track of which trees are visible
    boolean_matrix = Matrix()
    boolean_matrix.set_size(matrix.get_size())
    
    # iterate through each row
    for i in range(matrix.get_size()):
        longest_tree = -1
        row = matrix.get_row(i)
        boolean_row = boolean_matrix.get_row(i)
        # left-to-right check
        for j in range(len(row)):
            if row[j] > longest_tree:
                longest_tree = row[j]
                boolean_row.append(True)
                visible_tree_count += 1
            else:
                boolean_row.append(False)
        # right-to-left check
        current_highest_tree = -1
        for j in range(len(row)):
            index = len(row) - j - 1
            if row[index] > current_highest_tree:
                current_highest_tree = row[index]
                if boolean_row[index] == False:
                    boolean_row[index] = True
                    visible_tree_count += 1
            # stop if highest tree in row has been spotted
            if row[index] == longest_tree:
                break
            
    # iterate through each column
    for i in range(matrix.get_size()):
        longest_tree = -1
        column = matrix.get_column(i)
        boolean_column = boolean_matrix.get_column(i)
        # top-to-bottom check
        for j in range(len(column)):
            if column[j] > longest_tree:
                longest_tree = column[j]
                if boolean_column[j] == False:
                    boolean_column[j] = True
                    visible_tree_count += 1
        # bottom-to-top check
        current_highest_tree = -1
        for j in range(len(column)):
            index = len(column) - j - 1
            if column[index] > current_highest_tree:
                current_highest_tree = column[index]
                if boolean_column[index] == False:
                    boolean_column[index] = True
                    visible_tree_count += 1
                # stop if highest tree in column has been spotted
                if column[index] == longest_tree:
                    break
        
        # update column in matrix
        boolean_matrix.update_column(i, boolean_column)
    return visible_tree_count
        
def a(input):
    matrix = create_matrix(input)
    return count_trees(matrix)

def b(input):
    pass
