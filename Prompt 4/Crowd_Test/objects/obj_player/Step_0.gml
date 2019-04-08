// moving around

if (keyboard_check(vk_right) || keyboard_check(ord("D")))
	{
		x += 4;
	}
if (keyboard_check(vk_left) || keyboard_check(ord("A")))
	{
		x -= 4;
	}
if (keyboard_check(vk_up) || keyboard_check(ord("W")))
	{
		y -= 4;
	}
if (keyboard_check(vk_down) || keyboard_check(ord("S")))
	{
		y += 4;
	}

image_angle = point_direction(x,y,mouse_x,mouse_y);

// "shoot" or creating an instance of an object

if (mouse_check_button(mb_left))
	{
		instance_create_layer(mouse_x,mouse_y,layer,obj_burst);
	}