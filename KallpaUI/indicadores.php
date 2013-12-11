<?php 
$html = file_get_contents("https://www.google.com/finance");

if (preg_match('{<div class=sfe-section.*?>(.*?)</div>}s', $html, $matches))
{
    $varmarque = $matches[1];
    //$varmarque = $matches[1];
}

$varmarque = str_replace("/finance","https://www.google.com/finance",$varmarque);
$varmarque = str_replace("class=quotes","",$varmarque);
$varmarque = str_replace("class=symbol","",$varmarque);
$varmarque = str_replace("class=price","",$varmarque);
$varmarque = str_replace('class="change"',"",$varmarque);
$varmarque = str_replace("class=chr","",$varmarque);
?>
<!DOCTYPE html>
<html>
<head>
	<title></title>
	<link rel="stylesheet" href="bvl/style.css">
	<script src="bvl/jquery-1.10.2.min.js"></script>

</head>
<body>
<div>
	<?php echo $varmarque; ?>
</div>
</body>
</html>