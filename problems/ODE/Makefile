all: plot.svg

plot.svg: plot.gpi plot.txt
	gnuplot $<
plot.txt: main.exe
	mono $<
main.exe: main.cs ODE.dll
	mcs $< -reference:$(word 2,$^) $<

MATLIB = ../matlib
S := $(MATLIB)/matrix/vector.cs
ODE.dll: ODE.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f out* *.exe