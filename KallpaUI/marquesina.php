<?php 
$html = file_get_contents("http://www.bvl.com.pe");

if (preg_match('{<marquee id="id_marquee".*?>(.*?)</marquee>}s', $html, $matches))
{
    $varmarque = str_replace("/images/","bvl/",$matches[1]);
}
?>
<!DOCTYPE html>
<html>
<head>
	<title></title>
	<link rel="stylesheet" href="bvl/style.css">
	<script type="text/javascript">
	        function start_marquee()
	               { document.getElementById('id_marquee').start();
	               }
	</script>
</head>
<body>
<div class="marquee">
	<marquee id="id_marquee" name="id_marquee" behavior="scroll" direction="left" scrolldelay="100" onmouseover="this.stop()" onmouseout="this.start()">
	<?php echo $varmarque; ?>
	</marquee>
	<div class="text10">Actualizaci&oacute;n cada 20 minutos</div>
</div>
</body>
</html>