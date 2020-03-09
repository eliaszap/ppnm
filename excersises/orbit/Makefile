plot.svg: plot.gpi out.txt
	gnuplot $<
out.txt: main.exe 
		mono $< >$@
main.exe: main.cs matlib.dll
		mcs -reference:matlib.dll $< 
matlib.dll: ../matlib/ode/ode.cs ../matlib/matrix/vector.cs
	mcs -target:library -out:$@ $^


clean:
	rm -f rm *.exe out* 
