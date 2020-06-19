all: plotA.svg
	
plotA.svg: plotA.gpi plotA.txt
	gnuplot $<
	
plotA.txt: main.exe
	mono $<

main.exe: main.cs ODE.dll
	mcs $< -reference:$(word 2,$^) $<

MATLIB = ../../matlib
S := $(MATLIB)/matrix/vector.cs
ODE.dll: ../ODE.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f *.txt *.exe *.svg *.dll