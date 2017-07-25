all:
	xelatex finalReport
	xelatex finalReport
	(rm -rf *.ps *.log *.dvi *.aux *.*% *.lof *.lop *.lot *.toc *.idx *.ilg *.ind *.bbl *blg *.el *.out auto/)
	open *.pdf