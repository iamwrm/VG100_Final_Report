all:
	dot -T pdf -O figWR/a.dot 
	mv figWR/a.dot.pdf figWR/a.pdf
	dot -T pdf -O figWR/ma.dot 
	mv figWR/ma.dot.pdf figWR/ma.pdf
	dot -T pdf -O figWR/sc.dot 
	mv figWR/sc.dot.pdf figWR/sc.pdf
	xelatex -shell-escape finalReport 
	xelatex -shell-escape finalReport 
	cp /Users/wangren/Documents/Github/VG100_Final_Report/finalReport.pdf /Users/wangren/Documents/Nutstore/Wang
	(rm -rf *.ps *.log *.dvi *.aux *.*% *.lof *.lop *.lot *.toc *.idx *.ilg *.ind *.bbl *blg *.el *.out auto/)
	open finalReport.pdf