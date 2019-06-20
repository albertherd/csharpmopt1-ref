# Exploring micro optimizations in c# Part 1 - using ref with structs
Exploring micro optimizations in c# Part 1 - using ref with structs

Follow the accompanying blog post here - https://albertherd.com/2019/06/20/c-micro-optimizations-part-1-ref-arguments/

Exploring the performance differences when passing values by ref or by value with structs (value types). The bigger the struct is, the bigger the performance uplift.

![Performance differences in structs](https://albertherdcom.files.wordpress.com/2019/06/crefbenchmark-1.jpg?w=809?w=500)

When comparing a 16-byte struct, the performance differences when doing work by ref instead of by value is illustrated in the following benchmark. Work by ref exhibit around 72% lift in performance. 

<table>
<thead><tr><th>Method</th><th>limit</th><th>Mean</th><th>Error</th><th>StdDev</th>
</tr>
</thead><tbody><tr><td>BenchmarkIncrementByRef</td><td>1000000</td><td>1.663 ms</td><td>0.0139 ms</td><td>0.0130 ms</td>
</tr><tr><td>BenchmarkIncrementByVal</td><td>1000000</td><td>2.872 ms</td><td>0.0155 ms</td><td>0.0145 ms</td>
</tr></tbody></table>

Full description along with IL Analysis can be found in the blog post linked above.
