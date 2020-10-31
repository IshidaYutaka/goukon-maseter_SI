from sklearn.linear_model import LogisticRegression
import numpy as np
from sklearn.feature_selection import SelectKBest,f_regression,f_classif
from sklearn.linear_model import LinearRegression,Ridge,Lasso
from scipy.io import arff
from sklearn.model_selection import train_test_split
from sklearn.metrics import r2_score
from sklearn.metrics import mean_squared_error
from sklearn.model_selection import KFold
from sklearn import preprocessing
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import LeaveOneOut
import scipy.stats
import csv
import pprint
from sklearn.metrics import accuracy_score

class atr_estimate:
	"""docstring for atr_estimate"""
	def estimate(self,arff_path):
		dataset, meta = arff.loadarff("output.arff")
		ds=np.asarray(dataset.tolist(),dtype=float)
		selectNameList = [
			"audSpec_Rfilt_sma[5]_quartile2",
			"pcm_fftMag_mfcc_sma[13]_lpc0",
			"pcm_fftMag_mfcc_sma[13]_lpc3",
			"audSpec_Rfilt_sma_de[23]_quartile3",
			"audSpec_Rfilt_sma_de[23]_iqr2-3",
			"pcm_fftMag_mfcc_sma_de[6]_iqr1-2",
			"pcm_fftMag_mfcc_sma_de[6]_lpc0",
			"pcm_fftMag_mfcc_sma_de[12]_skewness",
			"pcm_fftMag_mfcc_sma_de[12]_upleveltime75",
			"pcm_fftMag_mfcc_sma_de[12]_downleveltime75",
			"pcm_fftMag_mfcc_sma_de[13]_lpc0",
			"F0final_sma_upleveltime25",
			"F0final_sma_upleveltime50",
			"F0final_sma_upleveltime75",
			"audSpec_Rfilt_sma[20]_minRangeRel",
			"pcm_fftMag_mfcc_sma[3]_qregc2",
			"pcm_fftMag_mfcc_sma[7]_stddevRisingSlope",
			"pcm_fftMag_mfcc_sma[12]_qregc1",
		]
		target=ds[:,-1]
		X=ds[:,:-1]
		#正規化 有効特徴量比較のため
		train = scipy.stats.zscore(X,ddof=1)
		X_new = SelectKBest(score_func=f_regression, k=18)
		X_new.fit_transform(train, target)
		X_selected = X_new.transform(train)
		#どの特徴量が選ばれたか
		# name_list= meta.names()
		# mask = X_new.get_support()
		# list = []
		# for f,w in zip(name_list,mask):
		#   if w :
		#     list.append(f)
		lr = LinearRegression()
		lr.fit(X_train,y_train)
		#print(lr.score(X_train,y_train))
		

		#player-output.arff
		player_dataset,player_meta = arff.loadarff(arff_path)
		player_ds=np.asarray(player_dataset.tolist(),dtype=float)
		# class 0 remove
		pX=player_ds[:,:-1]
		#正規化 有効特徴量比較のため
		p_train = scipy.stats.zscore(pX,ddof=1)
		p_X_selected = X_new.transform(p_train)
		print(p_X_selected.shape)
		result = lr.predict(p_X_selected)

		return result