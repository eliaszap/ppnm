all: plot.svg

plot.svg: plot.gpi out-cderivative.txt out-xy.txt out-cintegrate.txt out-cinterp.txt
	gnuplot $<
out-cderivative.txt out-xy.txt out-cintegrate.txt out-cinterp.txt: main.exe
	mono $< 
main.exe: main.cs cspline.dll
	mcs -reference:cspline.dll $<

MATLIB = ../../matlib
S := $(MATLIB)/matrix/vector.cs
S +=$(MATLIB)/integration/quado8.cs

cspline.dll: cspline.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.svg *.dll

