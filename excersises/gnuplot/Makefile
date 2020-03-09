all: Gamma.svg Gamma-error.svg

Gamma.svg: gamma.gpi out.gamma.txt out.gamma.test.txt
	gnuplot $<

Gamma-error.svg: gamma-error.gpi out.gamma.error.txt
	gnuplot $<

out.gamma.txt out.gamma.error.txt: main-gamma.exe
	mono $< > out.gamma.txt 2> out.gamma.error.txt

out.gamma.test.txt: gamma.c
	 	tcc -run $< > $@

main-gamma.exe: main-gamma.cs math.dll
	mcs $< -out:$@ -reference:math.dll

math.dll: gamma.cs
	mcs $< -target:library -out:$@

.PHONEY:clean
clean:
	rm --force *.dll *.exe out* *.svg