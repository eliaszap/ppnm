CSFLAGS = -optimize+ - platform:arm
.PHONEY:all
all: out.txt
	cat out.txt

out.txt : main.exe
	mono main.exe > out.txt
main.exe : main.cs cmath.dll
	mcs $(CSFALGS) -reference:cmath.dll -out:main.exe main.cs

cmath.dll: ../complex/cmath.cs ../complex/complex.cs
	mcs $^ -target:library -out:$@
	cp ../complex/cmath.dll .
clean: 
	rm --force out.txt main.exe

