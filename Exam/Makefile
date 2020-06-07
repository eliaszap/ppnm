all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs lanczos.dll
	mcs -reference:lanczos.dll $<

MATLIB = ../problems/matlib/
S :=$(MATLIB)/matrix/matrix.cs
S +=$(MATLIB)/matrix/vector.cs

lanczos.dll: lanczos.cs $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f *.exe out* *.dll