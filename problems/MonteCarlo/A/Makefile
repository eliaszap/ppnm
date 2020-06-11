all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs montecarlo.dll
	mcs -reference:montecarlo.dll $<

MATLIB = ../../matlib/
S :=$(MATLIB)/matrix/vector.cs

montecarlo.dll: ../montecarlo.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.dll