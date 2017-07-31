all:
	dot -T pdf -O figWR/a.dot 
	mv figWR/a.dot.pdf figWR/a.pdf
	xelatex finalReport
	xelatex finalReport
	(rm -rf *.ps *.log *.dvi *.aux *.*% *.lof *.lop *.lot *.toc *.idx *.ilg *.ind *.bbl *blg *.el *.out auto/)
	open finalReport.pdf