

#Accepts string and returns  if it's a palindrome
def CheckPalindrom(string):
    if string == "":
        #assuming empty string is a palindrome
        return True
    acceptableChars = range(65,90)
    start = 0
    end = len(string) -1
    while start != end:
        endc = string[start].upper()
        startc = string[end].upper()
        if ord(endc) not in acceptableChars:
            start += 1
            continue
        if ord(startc) not in acceptableChars:
            end += -1
            continue
        if endc != startc:
            return False
        start += 1
        end -= 1
    return True


print(CheckPalindrom("Madam, in Eden, I'm Adam"))
print(CheckPalindrom("Complete the project report"))
print(CheckPalindrom("el"))
