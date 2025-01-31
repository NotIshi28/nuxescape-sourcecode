using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15;


    public GameObject fpsCam;                   //The Point Of Shooting
    public GameObject impactEffect;             //Bullet Impact Effect
    public GameObject bulletCasing;             //Eject Used Casing
    public Transform casinglocation;            //Where The Casing Gets Ejected
    public AudioSource weaponSound;             //Weapon Sound Effect
    public AudioSource noAmmoSound;             //Empty Gun Sound 
    public AudioSource reloadSound;             //Reload Sound 

    public Animator anim;                       //Animations For Weapons
    public Vector3 reloading;                   //New Position For Reload
    public float reloadTime = 3;                //Time It Takes To Reload
    public Vector3 upRecoil;                    //New Position For Recoil
    Vector3 originalRotation;                   //Original Position

    public float amount;                        //Swaying Min Amount
    public float maxAmount;                     //Swaying Max Amount
    public float smoothAmount;                  //Smooth Time For Swaying

    private Vector3 initialPosition;            //Original Position Before Swaying

    // public GameObject ammoText;                 //Ammo Text

    private int currentAmmo;                    //The Current Ammo In Weapon
    public int magazineSize = 10;               //How Much Ammo Is In Each Mag
    public int ammoCache = 20;                  //How Much Ammo Is In Your Cache (Storage)
    private int maxAmmo;                        //Max Ammo Is Private MaxAmmo = Mag Size
    private int ammoNeeded;                     //Ammo Counter For How Much Is Needed, You Shoot 5 Bullets, You Need 5

    public bool semi;                           //Is the Weapon Semi
    public bool auto;                           //Is The Weapon Auto
    public bool melee;                          //Is The Weapon Melee

    //There Can Be A Bug Where The Casing Goes Reversed, These Two Bools Will Fix It:

    public bool casingForward;                  //Get Correct Orientation Of Casings
    public bool casingBackwards;                //Get Correct Orientation Of Casings

    private bool isreloading;                   //Is The Weapon Reloading
    private bool canShoot;                      //Is The Weapon Able To Be Shot

    private float nextTimeToFire = 0f;          //How Much Time Must Pass Before Shooting/Meleeing Again



    //Start Function To Ensure Theres No Bugs:

    void Start()
    {
        currentAmmo = magazineSize;
        maxAmmo = magazineSize;

        isreloading = false;
        canShoot = true;

        originalRotation = transform.localEulerAngles;
        initialPosition = transform.localPosition;


    }



    void Update()
    {

        //For Semi Auto Weapons:

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && semi && magazineSize > 0 && canShoot)
        {
            AddRecoil();
            nextTimeToFire = Time.time + 1f / fireRate;
            anim.SetBool("shoot", true);
            Invoke("setboolback", .5f);
            Shoot();
        }

        //For Weapons With Melee:

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && melee)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            anim.SetBool("melee", true);
            Invoke("setboolback", .5f);
            Melee();
        }


        //For Auto Weapons:

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && magazineSize > 0 && auto && canShoot)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            anim.SetBool("shoot", true);
            Invoke("setboolback", .5f);
            AddRecoilAuto();
            Shoot();
        }

        //Checks For 0 Ammo:

        if (Input.GetButton("Fire1") && magazineSize == 0)
        {
            noAmmoSound.Play();
        }

        else if(Input.GetButtonUp("Fire1") && canShoot)
        {

            StopRecoil();
        }

        //Changeing Animation Weapon Ammo 0:

        if (magazineSize == 0)
        {
            // ammoText.GetComponent<Text>().text = "Reload" ;
            anim.SetBool("empty", true);
        }

        if (magazineSize > 0)
        {
            anim.SetBool("empty", false);
        }


        //Reloading:

        if (Input.GetButtonDown("reload") && magazineSize == 0 && ammoCache > 0)
        {
            canShoot = false;
            ammoCache -= ammoNeeded;
            magazineSize += ammoNeeded;
            ammoNeeded -= ammoNeeded;
            isreloading = true;
            StartCoroutine(ReloadTimer());
            
        }

        //Stops Bugs With Pressing Reload More Than Once:

        else if(isreloading)
        {

            return;

        }

        //Doesnt Reload If Cache Is 0:

        if (Input.GetButtonDown("reload") && ammoCache == 0)
        {

            return;

        }

        //Tells Our Text Object What To Say:


        // ammoText.GetComponent<Text>().text = magazineSize + " / " + ammoCache;


        //Our Swaying Function Being Put To Action:

            float movementX = -Input.GetAxis("Mouse X") * amount;
            float movementY = -Input.GetAxis("Mouse Y") * amount;
            movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
            movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        //Making Sure The Sway Goes Back To Original Postion:

            Vector3 finalPosition = new Vector3(movementX, movementY, 0);
            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
        
     }


    //If Our Weapon Is A Gun:

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            ammoNeeded++;

            weaponSound.Play();



            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactOB = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(impactOB, 2f);


        }
     }


    //If Our Weapon Is Melee:

    void Melee()
    {
        weaponSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;

        Target target = hit.transform.GetComponent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

    }


    //Setting Animation Bools Back To Normal:

    public void setboolback()
    {
        anim.SetBool("shoot", false);
        anim.SetBool("melee", false);
    }


    //Adding Recoil Postion When Shot Semi Weapons:

    public void AddRecoil()
    {
        if (canShoot)
        {
            transform.localEulerAngles += upRecoil;
            StartCoroutine(StopRecoilSemi());
        }
    }

    //Adding Recoil Postion When Shot Auto Weapons:

    public void AddRecoilAuto()
    {
        if (canShoot)
        {
            transform.localEulerAngles += upRecoil;
            StartCoroutine(StopRecoilSemi());
        }
    }

    //Stopping Recoil:

    public void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }

    //Stopping Recoil (Fixing Bugs)

    IEnumerator StopRecoilSemi()
    {
        yield return new WaitForSeconds(.1f);
        transform.localEulerAngles = originalRotation;
    }

    //Our Reload Timer:

    IEnumerator ReloadTimer()
    {
        reloadSound.Play();
        transform.localEulerAngles += reloading;
        yield return new WaitForSeconds(reloadTime);
        isreloading = false;
        canShoot = true;
        transform.localEulerAngles = originalRotation;
    }
}