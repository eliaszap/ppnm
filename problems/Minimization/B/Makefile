all: plot.svg
	cat out.txt
plot.svg: plot.gpi higgs_data.txt out.error.txt
	gnuplot $<

out.txt out.error.txt: main.exe
	mono $< > out.txt 2> out.error.txt

main.exe: main.cs minimization.dll
	mcs $< -reference:minimization.dll $<

MATLIB = ../../matlib/
S :=$(MATLIB)/matrix/matrix.cs
S +=$(MATLIB)/matrix/vector.cs

minimization.dll: ../minimization.cs $(S)
		mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.dll	