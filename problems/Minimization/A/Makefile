all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs minimization.dll
	mcs $< -reference:minimization.dll $<

MATLIB = ../../matlib/
S :=$(MATLIB)/matrix/matrix.cs
S +=$(MATLIB)/matrix/vector.cs

minimization.dll: ../minimization.cs $(S)
		mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.dll	