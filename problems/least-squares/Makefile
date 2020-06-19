all: out-data.txt plot.svg out-expfit.txt
	
plot.svg: plot.gpi out-data.txt out-expfit.txt
		gnuplot $<

out-data.txt out-expfit.txt: main.exe
	mono $< 

main.exe: main.cs lsquares.dll
	mcs $< -reference:$(word 2,$^) $<

MATLIB = ../matlib
S := $(MATLIB)/matrix/qrdecompositionGS.cs
S += $(MATLIB)/matrix/matrix.cs
S += $(MATLIB)/matrix/vector.cs
lsquares.dll: lsquares.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f out* *.exe *.svg *.dll