all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > out.txt

main.exe: main.cs jaobi.dll
	mcs -reference:$(word 2,$^) $<	

MATLIB = ../matlib
S := $(MATLIB)/matrix/matrix.cs
S += $(MATLIB)/matrix/vector.cs
jaobi.dll: jaobi.cs  $(S)
	mcs -target:library -out:$@ $^

clean:
	rm -f rm *.exe out* *.svg
