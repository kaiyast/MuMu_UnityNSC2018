from optparse import OptionParser

def test(Atk):
	Mon_Hp = 50
	if Atk >= Mon_Hp:	
		print("Mon_Die")
	else:	
		print("Mon_Not_Die")

if __name__ == "__main__":
	optparser = OptionParser()
	optparser.add_option('-a','--atk', dest='atk',default=0,type='int')
	(options, args) = optparser.parse_args()
	
	atk = options.atk
	test(atk)