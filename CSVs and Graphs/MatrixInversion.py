import csv
from numpy.linalg import inv
from numpy import *
CSV = 'TransposeMatrixHere'
with open(CSV) as csvfile:
    readCSV = csv.reader(csvfile, delimiter=',')
    count = 0
    row1, row2, row3, row4, row5, row6, row7, row8, row9, row10 = [], [], [], [], [], [], [], [], [], []
    for row in readCSV:
        a = array(row)
        count = count + 1
        if count == 1:
            row1 = [float(numeric_string) for numeric_string in a]
        elif count == 2:
            row2= [float(numeric_string) for numeric_string in a]
        elif count == 3:
            row3 = [float(numeric_string) for numeric_string in a]
        elif count == 4:
            row4 = [float(numeric_string) for numeric_string in a]
        elif count == 5:
            row5 = [float(numeric_string) for numeric_string in a]
        elif count == 6:
            row6 = [float(numeric_string) for numeric_string in a]
        elif count == 7:
            row7 = [float(numeric_string) for numeric_string in a]
        elif count == 8:
            row8 = [float(numeric_string) for numeric_string in a]
        elif count == 9:
            row9 = [float(numeric_string) for numeric_string in a]
        elif count == 10:
            row10 = [float(numeric_string) for numeric_string in a]
    class VariableInitialization:
        def __init__(self, row1, row2, row3, row4, row5, row6, row7, row8, row9, row10):
            self.row1, self.row2, self.row3, self.row4, self.row5, self.row6, self.row7, self.row8, self.row9, self.row10 = row1, row2, row3, row4, row5, row6, row7, row8, row9, row10

    class Inverse(VariableInitialization):
        def __initInverse__(self):
            temp = vstack((row1, row2, row3, row4, row5, row6, row7, row8, row9, row10))
            temp_matrix = asmatrix(temp)
            inv_temp_matrix = inv(temp_matrix)
            A = asarray(inv_temp_matrix)
            savetxt('InverseMatrixHere', A, delimiter=',')

    calculation = VariableInitialization(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10)
    inverse = Inverse.__initInverse__(calculation)