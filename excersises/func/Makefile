all: out.txt
	cat out.txt

out.txt: main.exe
		mono $< >$@

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll -out:$@

LIBDIR = ../matlib
SRC = $(LIBDIR)/integration/quado8.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@


clean: 
	rm -f *.exe out*