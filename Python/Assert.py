
print("Asserting Bitch")

assert 3>2 #Asserting padrao which is bool

print("Yeah!")


import numpy as np

arr = np.array([1,2,3])

np.testing.assert_array_equal(arr,np.array([1,2,3])) #asserting to array

print("Yeaaaah!")


text = "teste"
assert text == "teste"

print("Pnultimate Yeah!")

#teste1 = str(10)

teste1 = 10 # It alsos checks its object type

assert teste1 == 10

print("Final Yeah!")
