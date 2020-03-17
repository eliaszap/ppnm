all: plot.svg

plot.svg: plot.gpi out-xy.txt out-linterp.txt out-lintegral.txt
	gnuplot $<

out-xy.txt out-linterp.txt out-lintegral.txt: main.exe
	mono $<  

main.exe: main.cs lspline.dll
	mcs -reference:lspline.dll $<

lspline.dll: lspline.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f rm *.exe out* *.svg

