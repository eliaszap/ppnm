all: plot.svg

plot.svg: plot.gpi out-qderivative.txt out-xy.txt out-qintegrate.txt out-qinterp.txt
	gnuplot $<
out-qderivative.txt out-xy.txt out-qintegrate.txt out-qinterp.txt: main.exe
	mono $< 
main.exe: main.cs lspline.dll
	mcs -reference:lspline.dll $<

MATLIB = ../../matlib
S := $(MATLIB)/matrix/vector.cs
S +=$(MATLIB)/integration/quado8.cs

lspline.dll: qspline.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.svg *.dll

