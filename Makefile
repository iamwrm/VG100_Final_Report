all:
	dot -T pdf -O figWR/a.dot 
	mv figWR/a.dot.pdf figWR/a.pdf
	dot -T pdf -O figWR/ma.dot 
	mv figWR/ma.dot.pdf figWR/ma.pdf
	dot -T pdf -O figWR/sc.dot 
	mv figWR/sc.dot.pdf figWR/sc.pdf
	xelatex finalReport
	xelatex finalReport
	(rm -rf *.ps *.log *.dvi *.aux *.*% *.lof *.lop *.lot *.toc *.idx *.ilg *.ind *.bbl *blg *.el *.out auto/)
	open finalReport.pdf