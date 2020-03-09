all: ms.pdf out.txt plot-gamma.tex
plot-gamma.tex: gamma.gpi out.txt
	gnuplot $<

out.txt: main.exe
	mono $< > out.txt 

main.exe: main.cs matlib.dll
		mcs $< -reference:matlib.dll -out:$@

LIBDIR = ../matlib
SRC = $(LIBDIR)/integration/quado8.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

ms.pdf:  ms.tex
	pdflatex $<
	pdflatex $<

clean: 
	$(RM) *.log *.aux *.pdf *.dvi