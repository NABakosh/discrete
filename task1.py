def join(a,b):
    for i in b:
      if i not in a:
          a.append(i)
    return a
    print("join")
def intersection(a,b):
    print("intersection")
    result = []
    for i in b:
        if i in a:
            result.append(i)
    return result
def difference(a,b):
    result = []
    for i in a:
        if i not in b:
            result.append(i)
    print("difference")
    return result
def symmetricDif(a,b):
    result = []
    for i in b:
        if i not in a:
            result.append(i)
    for i in a:
        if i not in b:
            result.append(i)
    print("symmetricDif")
    return(result)
def powerSet():
    print("powerSet")
def decarto():
    print("decarto")
def main():
    print('Main')
    print(symmetricDif([1,2,3,12124,4,5],[3,2,4,6,7,8]))

main()