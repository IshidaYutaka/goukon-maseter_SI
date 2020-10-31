class TextEdit2:

	def edit(self,path):
		#IS2012用
		file1=open(path,'r',encoding='utf-8')
		result=[]
		for line in file1:
			result.append(line)
		data=result[5764:]
		data_atr=result[:5764]
		arff=[]
		atr=[]
		for line2 in data:
			arff.append(line2.lstrip("'unknown,'"))
		for line3 in data_atr:
			if line3==result[2]:
				print("成功だ!")
				continue
			atr.append(line3)
		atr.append(arff)
		with open(path, mode='w') as w:
		 	for wr in atr:
		 		w.writelines(wr)
		w.close()
		file1.close()
		#IS2009用
		# file2 = open(path3,'r',encoding='utf-8')
		# result2 = []
		# atr2 = []

		# for line3 in file2:
		# 	result2.append(line3)

		# for line4 in result2:
		# 	arff.append(line4.lstrip("'unknown,'"))

		# atr2.append(arff)
		# with open("output2.arff", mode='w') as w:
		#  	for wr in atr2:
		#  	  w.writelines(wr)
		# w.close()
		# file2.close()
