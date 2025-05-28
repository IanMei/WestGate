USE WestGate;

INSERT INTO Region (region_id, province, city, district, zone_name) VALUES
(1, 'Beijing', 'East Jamieville', 'Sean Spring', 'Zone 1'),
(2, 'Shanghai', 'East Joyfurt', 'Young Forge', 'Zone 2'),
(3, 'Guangdong', 'East Williamport', 'Lisa Street', 'Zone 3'),
(4, 'Jiangsu', 'Barbaramouth', 'Kevin Divide', 'Zone 4'),
(5, 'Zhejiang', 'South Kevin', 'Angela Ramp', 'Zone 5');

INSERT INTO School (school_id, school_name, region_id, established_year, school_type, status, address, area_size_mu, building_area_m2, website) VALUES
(1, 'Sunrise Academy', 2, 1998, 'AP', 'closed', '687 Teresa Row, Floydmouth, MT 54012', 28.65, 9105.17, 'http://school1.edu.cn'),
(2, 'Maple Leaf School', 4, 2000, 'British', 'closed', '1401 Melinda Rue Apt. 238, New Ethan, NE 61063', 43.65, 3891.01, 'http://school2.edu.cn'),
(3, 'Global Horizon International', 5, 2004, 'IB', 'closed', '9252 Ayala Ports, East Joycetown, AL 32554', 39.94, 8938.35, 'http://school3.edu.cn'),
(4, 'Bright Future School', 5, 2018, 'AP', 'pending', '3368 Guerrero Hills, North Brandon, OH 64850', 37.55, 6050.85, 'http://school4.edu.cn'),
(5, 'Evergreen International School', 5, 1990, 'Local Bilingual', 'closed', '1847 Jamie Spur Apt. 461, Cindyberg, CT 67555', 74.19, 9707.21, 'http://school5.edu.cn'),
(6, 'Harmony IB Academy', 3, 2007, 'IB', 'closed', '583 Abigail Turnpike, South Amy, CO 46297', 95.85, 3599.29, 'http://school6.edu.cn'),
(7, 'Windsor College Prep', 4, 2005, 'British', 'pending', '3009 April Lane Apt. 565, East Ronaldshire, KS 70769', 34.75, 3359.64, 'http://school7.edu.cn'),
(8, 'Riverstone Bilingual School', 2, 2019, 'Local Bilingual', 'active', '774 Katie Union, Carlatown, MN 25217', 25.71, 4161.46, 'http://school8.edu.cn'),
(9, 'North Star IB School', 5, 2016, 'IB', 'closed', '938 John Grove Suite 591, Lake Robertstad, ID 42540', 89.55, 6233.83, 'http://school9.edu.cn'),
(10, 'Royal British School', 4, 2007, 'British', 'pending', '2934 Aaron Burg Suite 139, Gutierrezmouth, OH 84059', 46.6, 8340.11, 'http://school10.edu.cn'),
(11, 'Pioneer AP School', 1, 2004, 'AP', 'closed', '940 Lane Ports Apt. 490, Toddberg, CA 36919', 43.96, 3202.63, 'http://school11.edu.cn'),
(12, 'Lakeside Bilingual', 4, 2016, 'Local Bilingual', 'active', '10822 Todd Crescent Apt. 379, Robertmouth, WI 14936', 68.57, 5466.25, 'http://school12.edu.cn'),
(13, 'Innovation IB School', 2, 2005, 'IB', 'closed', '26487 Mackenzie Hollow, Troymouth, AK 00821', 90.74, 6929.85, 'http://school13.edu.cn'),
(14, 'Excel AP Academy', 2, 1992, 'AP', 'closed', '919 Nelson Port, Simmonsstad, CA 85899', 37.28, 9087.87, 'http://school14.edu.cn'),
(15, 'Prime IB Institute', 4, 1993, 'IB', 'closed', '4948 Graham Expressway Suite 728, Brownberg, IN 24505', 72.07, 8382.74, 'http://school15.edu.cn'),
(16, 'Green Valley School', 5, 2019, 'Local Bilingual', 'active', '4821 Watson Throughway Suite 532, Cobbberg, NE 54687', 34.43, 7918.89, 'http://school16.edu.cn'),
(17, 'Aspire AP School', 5, 2012, 'AP', 'closed', '20970 Emily Loop Suite 681, New Anthonymouth, DE 46768', 64.7, 7676.34, 'http://school17.edu.cn'),
(18, 'Twin Rivers Bilingual', 5, 2004, 'Local Bilingual', 'closed', '3544 Lee Rapids, Port Karen, ND 34728', 45.29, 6078.34, 'http://school18.edu.cn'),
(19, 'Pinnacle AP School', 3, 1998, 'AP', 'pending', '344 Faulkner Flats, Michellefort, MN 52699', 26.52, 7645.28, 'http://school19.edu.cn'),
(20, 'Cambridge Prep', 2, 2001, 'British', 'pending', '201 Mccann Fall Apt. 185, Bookerfurt, AZ 16072', 81.56, 8446.87, 'http://school20.edu.cn');

INSERT INTO SchoolTranslation (school_id, lang_code, name, description, philosophy, facilities) VALUES
(1, 'en', 'School EN 1', 'Heavy senior list support feeling. South trip none whose.
Care drug data position two suggest begin. Appear help painting always authority. Right next look thank four whatever address view.', 'Seven floor data fine animal ten scientist.', 'Network once result far cultural.
Now early nearly want front shake. Whom politics make collection some college result.
True my politics arrive. Stuff avoid stand. Share include successful.'),
(1, 'zh', '学校中文 1', 'Within admit spend purpose south travel blood. Modern drive people education.
Some bad where learn during. Feel stock ball yard practice. Behavior here need.', 'Little another avoid understand tonight nor allow.', 'Which onto sell. Up federal nor note support quality. Forward sense cause write right may window.
Join stuff future shoulder.'),
(2, 'en', 'School EN 2', 'Picture control price how scene third. Or home relate day sell speak artist.
Cost for leader energy television month police. Home hotel box goal leader common purpose song.', 'Important man report kitchen cold not somebody.', 'Allow different eye sit not. Near both box simple statement happen state.
National wrong bill stop seem fear.
Enjoy television beautiful tend bring speech decide.'),
(2, 'zh', '学校中文 2', 'Reduce car chair focus. Seven put majority officer environmental.
Later plant they behavior middle everything. Lawyer maintain old than suggest behavior. Play recently sure somebody huge why station.', 'Think few themselves theory.', 'Economy head tough close how figure. Investment before believe degree back.'),
(3, 'en', 'School EN 3', 'Hair turn condition whether along sort research.
Focus indicate result even back. Budget pull apply development middle animal. Attention let executive suddenly force network.', 'Young simply run national somebody character usually.', 'Must player really act friend.
Billion morning draw man art. Republican behavior TV today. Including time learn security oil measure PM.'),
(3, 'zh', '学校中文 3', 'Last finish building group. Later leg system bed space.
American structure foreign before eat green message quality. Star community weight take new.', 'Business walk anything under item right.', 'Him interview government. Every land chance pass. Early far include nearly article evidence case current.
Piece soon some writer site. Look sit general not focus establish. Five despite time.'),
(4, 'en', 'School EN 4', 'Guess into far. Outside current agent color factor bank such final.
Major produce before name continue those hard. And keep enjoy student nor character recent. Beat gas must wife.', 'Challenge organization floor road southern beautiful news need.', 'Leader them skill performance mission information increase. Note old who beyond.
Single size test they there enough pressure. Participant also every century participant really although.'),
(4, 'zh', '学校中文 4', 'Population could deep station scientist service test start. Social assume remember idea sister modern notice. Cover strategy student economic.', 'Anyone take sister Democrat determine different.', 'Prepare message ten whose radio. Treatment positive over across education source figure.
Time surface learn design few minute. However bill memory production successful hear positive participant.'),
(5, 'en', 'School EN 5', 'Executive size marriage participant. Story win group important civil. Many debate value former able public trade. Protect chance bed memory rich big eight.', 'Forget thus western environmental.', 'Spring consumer husband while even history. Son power someone both receive around wall.
Indeed opportunity soon question. Particularly single particularly television.'),
(5, 'zh', '学校中文 5', 'Item risk loss professional. Chance step throughout party activity various. Support system thank avoid man drive wife. Medical nearly her.', 'Social white point three.', 'Pressure lay future stay staff. Forward should outside respond guy laugh best. Able great plant son natural.'),
(6, 'en', 'School EN 6', 'Professional former family wear peace. You statement wonder across protect knowledge toward.', 'Mrs reflect wish simple position.', 'Agency response also available. Some newspaper offer direction.
Hold picture item admit pull movement. As second animal summer group me face rate.'),
(6, 'zh', '学校中文 6', 'Natural be decide scientist rise deep town. Central contain pattern education boy provide note. Surface usually yes.', 'Republican political everybody growth quickly.', 'Leg grow figure necessary compare parent success. Through cultural safe phone. Throughout support place spend.'),
(7, 'en', 'School EN 7', 'Hand every quite sense including six lot. Next low write officer similar huge. Talk process security land.
Democrat hundred full nearly. Claim who accept.', 'Arm similar compare manager action sure us million.', 'Six member recognize. College already dream a church you sister good.
Only military say attention bed expect. Trip give white everybody paper create upon. Above company media next me future bring.'),
(7, 'zh', '学校中文 7', 'Movie red enjoy expert human see garden. Use live government thus especially water raise. Material current save their deal.
Student green single build bad. Pass share must amount lot per manage.', 'Activity decision ok.', 'Party employee nature down likely party. Contain interest industry sell half hundred. Conference capital office direction between establish dog.'),
(8, 'en', 'School EN 8', 'Join economic resource position stock determine bad. Dream share travel space range expect sea speak. Could attention carry book lay laugh.', 'Window research his window.', 'Current same behind. List race fine follow pick.
Minute education police cup thought tell design.
Plan foot cold everybody build. Across among situation little other.'),
(8, 'zh', '学校中文 8', 'Religious next my majority note myself food.
Test out team civil most. Fast enjoy happen a point here control. People hair per.', 'Blood court all politics home.', 'Perhaps opportunity any determine responsibility actually TV. Up story life police guess sea three. Some around pay more same strong.'),
(9, 'en', 'School EN 9', 'Pretty show college glass start sort perhaps key. Current health serious table both. Drug per challenge.
Gas sound figure. Age decade Mrs data model else low.', 'At produce production.', 'Affect test power discuss. Meet report tough machine others because. May leader unit again easy.
Four hotel church get goal. Few you without every artist election hit yourself. Want we difficult.'),
(9, 'zh', '学校中文 9', 'Involve training show prevent. True fish newspaper we brother fish they. She they increase.', 'Light power contain hold listen clearly difficult impact.', 'Wear development provide dark daughter.
Term majority foot leader east if. Part station result.
Voice occur movie political region although body lead. There early Mrs. Newspaper might piece.'),
(10, 'en', 'School EN 10', 'Political real effort. Film media food accept.
How notice whether story create street. Trouble something population loss physical throughout Mr. Leg sport until argue minute north.', 'Theory he stop few modern company hear.', 'Tree kitchen agent lot matter.
Type run model simply century the. Quality car right least require mission about.
The four threat billion she seat against serve.'),
(10, 'zh', '学校中文 10', 'Go five center region exist each author. Throughout music anything ahead tough anyone himself beat.', 'Like water century time election guy contain.', 'Law air little goal leave color. Page camera bill stage someone for. Society mouth husband including.'),
(11, 'en', 'School EN 11', 'Past every either scientist. Company option character land space end red machine.
Garden base certain. Study sell include himself. Rise cold official success approach enough.', 'High firm morning what best most government.', 'Truth teach friend environment better pressure hospital significant. Same open crime front real. Finish action across attack.'),
(11, 'zh', '学校中文 11', 'Prevent tonight not whose to receive. Far produce away law yet.
Either sit everyone artist home you. Western enough key man up. Hotel population board music issue pass blood kid.', 'Professor entire record.', 'About remain side long identify road speech. Music about west stand. Building movement yard four field area young.
Movement which ball least short possible. Never whose produce federal.'),
(12, 'en', 'School EN 12', 'Better scene thank heart determine. One approach job democratic participant concern health. Rest place wish dark camera realize arrive.', 'Talk beat tax majority yet option student.', 'Role save east. Its develop until watch trial together.
Always likely shoulder. International hour special. Laugh drive next actually.'),
(12, 'zh', '学校中文 12', 'His real most fast. Recently partner offer debate range. Thing save area war push thousand book half. American hand possible relate night similar catch friend.', 'Question mouth factor per son war speak.', 'Throughout leader bag today eye. Body every recent many.
Weight age indicate radio use listen information. Factor as the.'),
(13, 'en', 'School EN 13', 'Feel policy PM buy program. Individual man reach each budget.
Yes at seat ok not than physical. Window stand health run adult employee ok.', 'Out cold follow first.', 'Rate read benefit oil statement. Carry example single.
Tv clear design me story somebody. Party story moment mother necessary series box. Trouble bring capital admit give reality catch.'),
(13, 'zh', '学校中文 13', 'Soldier message arrive. Training analysis feeling act.
Turn day top continue. Ahead certainly second everyone often goal.', 'Interest method imagine seven fire letter.', 'Many guess explain reveal. Foreign break exist outside. Reach subject difficult imagine world.
Task thus sort voice happen. Your man black. Mission put budget house reason within.'),
(14, 'en', 'School EN 14', 'Sound item music customer I person law. Congress affect reflect television officer defense while.', 'Position either over image box.', 'Early still less. Yard instead town dark evening ahead smile.
Compare system white magazine after teacher base. Fear as western to public though however style.'),
(14, 'zh', '学校中文 14', 'Very design blood degree ever. Effect operation make hear we first. Little east everyone six certain little.', 'Home travel hotel within eight bed.', 'Decision three trouble place these. Smile ever bag single man say.
Theory star station recognize media goal. Role natural force receive seven political contain kitchen. Able customer figure office.'),
(15, 'en', 'School EN 15', 'Employee relationship job yet until American ground.
Leader both rest challenge glass data exist. Seek state none production. On will moment number indicate.', 'Ahead least remain look.', 'Order accept wide prevent week. Water yourself trade someone can tell. Follow area audience weight high. Effort drive side human after decade.'),
(15, 'zh', '学校中文 15', 'Pass its international American game less. Positive require us money positive. Fact join trade local.
Range feel eat into. Answer baby and blue interesting behind produce.', 'Section page the blood.', 'Accept bring commercial. Least if price season rise field spend. Guess purpose real house few by add born.
Teacher decide possible power job.'),
(16, 'en', 'School EN 16', 'Weight might radio want kind show response. Want be fire word clearly article service. Total around place require.', 'Simple thing base Mr hope rest.', 'Yeah exist behavior necessary miss serious civil. Three music else.
Would book art health phone great. Series walk large.'),
(16, 'zh', '学校中文 16', 'Better Republican stock bank artist thousand live. Back quality idea next single the once. You ready way rule indicate clear.', 'Magazine social central operation any.', 'Democratic standard major business give. Individual of not.
Little result paper seven measure leave. Project chance road become person perhaps hold. Fund animal provide kitchen everyone because.'),
(17, 'en', 'School EN 17', 'Group concern should recent across leg view know. Sea serve quite remember course. Personal space determine woman whose already manage region.', 'Third ability interview pull practice take follow.', 'Business million many military analysis. Another truth mother first hot. Bank occur agent scene within interest.
Culture forget as personal agreement. Space or phone free economy blue.'),
(17, 'zh', '学校中文 17', 'Site artist sort area. Phone assume quality nice far high benefit sell. Ten skin perhaps law less.', 'On must certainly light owner.', 'Wife military price certain down standard. Teach instead crime customer training size game.'),
(18, 'en', 'School EN 18', 'Example get you watch state.
Pressure writer week tend dinner rich decide.
Only need light sport future beat suffer. Show recently decide last next hear.', 'Picture owner part term woman daughter hospital.', 'Could board notice later thus behavior. Push concern step owner. Cost attorney white.
Do process attorney arm million. Force travel hospital writer.'),
(18, 'zh', '学校中文 18', 'Ask human space moment travel these least. Although before position try get successful society.', 'Building hard sense mean single improve close.', 'And ago police put left gas human. However action boy true force.
Leave bar prevent require just likely evidence. Color adult beyond family. Scientist collection provide action event key concern.'),
(19, 'en', 'School EN 19', 'Likely institution participant item. Standard soldier after high. Serve TV organization check.
Herself figure exist no lose. Carry light choice couple actually may.', 'Recent prepare unit save drug alone.', 'Religious agreement program challenge painting want challenge easy. Weight success activity side popular true huge only. Million country institution stop.'),
(19, 'zh', '学校中文 19', 'Us huge final would staff. Best similar individual.
Run color hear region cup. Me book note defense. Arrive consumer service else total.', 'Smile among decision social heart mind while entire.', 'Series page from radio gas firm dream. Professor her arm green form beyond. That I structure understand agent but most.
Later rather thank method produce about. Admit growth animal space for know.'),
(20, 'en', 'School EN 20', 'Major read west present heart reality. Sing ten practice every.', 'Spend after new movie speech major.', 'Much standard prepare send debate probably bring television. Accept language fire always. Deal claim none surface alone woman media.'),
(20, 'zh', '学校中文 20', 'Task Democrat care need option. Campaign performance avoid effort high.
Lay war put vote century data. Run yet recent cover head price star painting.', 'Event better woman develop weight.', 'Money then open southern. More red tend necessary.');

INSERT INTO Accreditation (accreditation_id, school_id, organization_name, certified, certification_date) VALUES
(1, 1, 'WASC', 0, '2021-02-15'),
(2, 2, 'NCCT', 0, '2022-12-27'),
(3, 3, 'NCCT', 0, '2020-06-22'),
(4, 4, 'NCCT', 0, '2022-01-16'),
(5, 5, 'NCCT', 1, '2025-01-03'),
(6, 6, 'WASC', 0, '2023-10-18'),
(7, 7, 'WASC', 1, '2024-01-20'),
(8, 8, 'CIS', 0, '2024-11-26'),
(9, 9, 'WASC', 0, '2023-08-05'),
(10, 10, 'NCCT', 1, '2020-07-10'),
(11, 11, 'WASC', 0, '2023-10-27'),
(12, 12, 'NCCT', 1, '2022-06-14'),
(13, 13, 'WASC', 0, '2022-04-28'),
(14, 14, 'CIS', 1, '2024-01-26'),
(15, 15, 'WASC', 0, '2024-02-24'),
(16, 16, 'CIS', 1, '2024-06-09'),
(17, 17, 'CIS', 0, '2021-09-29'),
(18, 18, 'NCCT', 1, '2023-04-28'),
(19, 19, 'NCCT', 1, '2021-06-13'),
(20, 20, 'CIS', 0, '2023-12-27');

-- SchoolImage table without NULLs
INSERT INTO SchoolImage (image_id, school_id, image_url, caption, upload_date) VALUES
(1, 1, 'https://placeimg.com/178/383/any', 'News mention billion bed never others six.', '2023-04-11'),
(2, 2, 'https://placeimg.com/436/310/any', 'Rather team beautiful beyond sell operation himself white.', '2022-09-04'),
(3, 3, 'https://placekitten.com/449/795', 'Compare or south recently.', '2025-01-11'),
(4, 4, 'https://placekitten.com/116/827', 'Return pretty young else.', '2023-07-24'),
(5, 5, 'https://placeimg.com/252/922/any', 'What care material morning any very stuff lot.', '2024-04-28'),
(6, 6, 'https://dummyimage.com/326x366', 'Voice American seven discussion enough doctor protect.', '2024-05-28'),
(7, 7, 'https://placekitten.com/197/921', 'Guess night use election after.', '2021-01-11'),
(8, 8, 'https://placeimg.com/733/939/any', 'Coach Congress husband front.', '2021-05-06'),
(9, 9, 'https://dummyimage.com/602x111', 'Stop later reveal both single visit receive.', '2021-02-24'),
(10, 10, 'https://dummyimage.com/185x445', 'Tough player a chair chance most hope official.', '2021-08-30'),
(11, 11, 'https://placekitten.com/33/75', 'Front return if deep.', '2024-06-13'),
(12, 12, 'https://placekitten.com/96/303', 'Lay coach under Republican expect.', '2021-06-28'),
(13, 13, 'https://placeimg.com/819/729/any', 'Wear would memory challenge lawyer business majority discuss.', '2021-02-22'),
(14, 14, 'https://dummyimage.com/273x533', 'Step son cup increase consider then war this.', '2021-11-28'),
(15, 15, 'https://www.lorempixel.com/474/124', 'Office network environmental possible threat bring.', '2025-04-18'),
(16, 16, 'https://www.lorempixel.com/387/974', 'Probably mother while ever.', '2021-10-01'),
(17, 17, 'https://www.lorempixel.com/819/377', 'Act group never central key place.', '2023-01-23'),
(18, 18, 'https://www.lorempixel.com/631/909', 'Above significant short up hear draw before instead.', '2020-02-15'),
(19, 19, 'https://placeimg.com/183/216/any', 'Civil upon total.', '2022-05-21'),
(20, 20, 'https://placeimg.com/587/564/any', 'Walk thing sport figure teach water image.', '2022-08-29');

-- GraduateDestination table without NULLs
INSERT INTO GraduateDestination (destination_id, school_id, country, num_students, year) VALUES
(1, 1, 'UK', 19, 2018),
(2, 1, 'UK', 30, 2020),
(3, 2, 'Canada', 40, 2018),
(4, 2, 'Australia', 23, 2019),
(5, 3, 'Canada', 44, 2023),
(6, 3, 'Canada', 40, 2021),
(7, 4, 'UK', 34, 2019),
(8, 4, 'USA', 30, 2022),
(9, 5, 'USA', 49, 2020),
(10, 5, 'USA', 41, 2018),
(11, 6, 'Canada', 6, 2018),
(12, 6, 'Australia', 19, 2021),
(13, 7, 'USA', 14, 2019),
(14, 7, 'Australia', 10, 2019),
(15, 8, 'Australia', 49, 2021),
(16, 8, 'Australia', 37, 2022),
(17, 9, 'USA', 18, 2020),
(18, 9, 'UK', 23, 2021),
(19, 10, 'Canada', 19, 2021),
(20, 10, 'USA', 25, 2023),
(21, 11, 'UK', 20, 2022),
(22, 11, 'Canada', 41, 2023),
(23, 12, 'USA', 45, 2023),
(24, 12, 'USA', 24, 2021),
(25, 13, 'USA', 13, 2018),
(26, 13, 'USA', 24, 2021),
(27, 14, 'Australia', 16, 2018),
(28, 14, 'USA', 13, 2018),
(29, 15, 'Canada', 30, 2021),
(30, 15, 'USA', 25, 2021),
(31, 16, 'Canada', 9, 2019),
(32, 16, 'USA', 10, 2023),
(33, 17, 'USA', 34, 2018),
(34, 17, 'Australia', 41, 2021),
(35, 18, 'Australia', 37, 2018),
(36, 18, 'Australia', 34, 2021),
(37, 19, 'Australia', 40, 2021),
(38, 19, 'Australia', 13, 2023),
(39, 20, 'USA', 46, 2021),
(40, 20, 'Australia', 40, 2018);

INSERT INTO NewsPost (post_id, school_id, published_at) VALUES
(1, 1, '2025-01-03 09:30:41'),
(2, 2, '2025-01-28 03:39:21'),
(3, 3, '2025-01-06 11:27:07'),
(4, 4, '2025-03-20 13:34:03'),
(5, 5, '2025-02-04 09:49:23'),
(6, 6, '2025-03-12 03:33:12'),
(7, 7, '2025-03-10 04:12:00'),
(8, 8, '2025-04-14 16:09:23'),
(9, 9, '2025-03-18 07:49:25'),
(10, 10, '2025-02-09 22:27:10'),
(11, 11, '2025-03-31 00:09:38'),
(12, 12, '2025-05-18 12:02:13'),
(13, 13, '2025-01-06 18:31:17'),
(14, 14, '2025-01-05 00:37:49'),
(15, 15, '2025-05-06 11:24:58'),
(16, 16, '2025-02-17 15:07:07'),
(17, 17, '2025-01-09 12:36:40'),
(18, 18, '2025-03-07 11:04:38'),
(19, 19, '2025-02-12 19:01:36'),
(20, 20, '2025-01-18 12:05:08');

INSERT INTO NewsPostTranslation (id, post_id, lang_code, title, content) VALUES
(1, 1, 'en', 'News Title 1', 'Hold be top toward within occur. Rate college especially environmental. Cold every feel site. Edge east person order crime blood. We forward per. Key issue statement prepare organization feel.'),
(2, 1, 'zh', '新闻标题 1', 'Plan drug probably resource. Available wrong look husband media turn. Myself so growth time Mr point. Shoulder price great positive. None population position.'),
(3, 2, 'en', 'News Title 2', 'Popular easy over return expect. Summer probably feeling.'),
(4, 2, 'zh', '新闻标题 2', 'Democratic two we huge expert. Interest I policy Mrs check base. Memory data space movie. Only shake power poor financial join. Each under break partner. Finally score scientist budget.'),
(5, 3, 'en', 'News Title 3', 'Nor none could write think man finally. Also argue own after long forward pass. Future concern sort than. Challenge relate center. Suffer team whether health.'),
(6, 3, 'zh', '新闻标题 3', 'Hot yes whole allow own TV whose. Bit many former back get floor player. Start prove role from. Decide really go skin result. Just information coach increase think goal.'),
(7, 4, 'en', 'News Title 4', 'On yes staff. Risk develop movement size trade public. Feel color price next family likely scientist. Water tonight pressure develop. Season film small former end. Less brother approach plant oil.'),
(8, 4, 'zh', '新闻标题 4', 'Size sister can its investment investment local. Also current health. Series most adult above safe difficult. Can himself open cold statement. Way lay minute model its. Garden top grow could.'),
(9, 5, 'en', 'News Title 5', 'Room campaign hold over. Mean his woman trouble several event. Wife laugh card include record security. Successful natural finish say network. Decide research rather TV car. Mean reason follow break.'),
(10, 5, 'zh', '新闻标题 5', 'Send allow sport bill test. Ten score night down six sometimes explain. Hold what wish fine need actually. Per sit thank stop treatment. Sense national owner simply who family.'),
(11, 6, 'en', 'News Title 6', 'Truth thing always possible billion why plant. Strong enjoy name community president. Onto together back edge win development.'),
(12, 6, 'zh', '新闻标题 6', 'Decision claim street against amount of claim. Mention three chair coach two might if wide. These road start. Last yeah test color store. Central old should perhaps member cold rate two.'),
(13, 7, 'en', 'News Title 7', 'Officer practice Mrs without expect. Pull maintain say threat high expert. What than political up instead partner if trade. Class direction first fact.'),
(14, 7, 'zh', '新闻标题 7', 'Cold billion as these nature. Side model you. Peace base use hope director. Kitchen call money color along.'),
(15, 8, 'en', 'News Title 8', 'Value total nearly you suddenly include. Step food drive nation heart nearly. Growth laugh where a alone. Other military year few feel.'),
(16, 8, 'zh', '新闻标题 8', 'Do specific begin hundred truth. Rich society common stay. Standard believe politics also space high sister. Girl stage indicate test thank dinner.'),
(17, 9, 'en', 'News Title 9', 'Late condition opportunity Republican dark lawyer. Food possible represent clearly run. Box last guy model.'),
(18, 9, 'zh', '新闻标题 9', 'About she activity marriage material. Part management describe. Improve bag outside each natural people newspaper. Any challenge president already take. Study fear turn any indicate condition public.'),
(19, 10, 'en', 'News Title 10', 'Now tree fight wall itself. Wrong old particularly member summer system. Hard nature apply reflect. Technology tend dog reduce. Personal Republican image itself deep community. Could his under style.'),
(20, 10, 'zh', '新闻标题 10', 'Perhaps lawyer interest star his difficult. Painting official suggest door maybe improve. Office almost also low happy oil which. Center rule worker worker.'),
(21, 11, 'en', 'News Title 11', 'Scientist do author save. President likely truth animal red candidate common. Toward star best.'),
(22, 11, 'zh', '新闻标题 11', 'Card social place. Sing administration main according conference become. Thought indicate southern significant realize deal policy mission. Dream company reality other response partner.'),
(23, 12, 'en', 'News Title 12', 'Draw American first call. Hard day religious program within. Large wish move building agent use. Way until choose wife.'),
(24, 12, 'zh', '新闻标题 12', 'Husband subject land. For part crime money. Against Mrs knowledge public beautiful. Hour make owner memory argue project huge.'),
(25, 13, 'en', 'News Title 13', 'Store marriage ago. Him quickly check perform. Produce mind man letter. Product make energy gas teacher. Weight all involve. Himself fire heavy least. Computer process single.'),
(26, 13, 'zh', '新闻标题 13', 'Short expect article opportunity campaign hand. Agree through game best generation group goal product. Doctor fine be read than. Front after for leave.'),
(27, 14, 'en', 'News Title 14', 'Positive phone trade wind cup red collection.'),
(28, 14, 'zh', '新闻标题 14', 'Society agreement wish dog late eat. Range leader action card follow realize rather require.'),
(29, 15, 'en', 'News Title 15', 'Recently again explain court gas discussion detail. Two table resource life third rich. Where strategy pull same somebody son.'),
(30, 15, 'zh', '新闻标题 15', 'Southern front box. Building difference election future great. Show news to.'),
(31, 16, 'en', 'News Title 16', 'Be move fly open man value. Join increase teacher fish either boy. My experience consumer shoulder. Fill imagine college pass.'),
(32, 16, 'zh', '新闻标题 16', 'Imagine do though. Never only big several prepare. Fight image base player. Health world site Mr. Which new among spend which per. Art two event. Style herself goal place one.'),
(33, 17, 'en', 'News Title 17', 'Cup company those responsibility fund. Condition again successful treat again. Her skin book very. Lay hard head commercial money.'),
(34, 17, 'zh', '新闻标题 17', 'Material less focus hear reason resource. Listen ok point so power debate thus. Tell how fill thousand number very hear.'),
(35, 18, 'en', 'News Title 18', 'Determine think someone store. Right analysis mention spring. Phone person various house into discussion black. Community I first home learn at. Practice hard attack despite feeling.'),
(36, 18, 'zh', '新闻标题 18', 'Scene serious people art hear. Dark heart politics draw rise. Care fish skin always social increase. Seek director run garden day. Trade professor eat.'),
(37, 19, 'en', 'News Title 19', 'Week provide program two plant man somebody. The use short over popular help. Whom join do else fact born future. Visit seat break happy table west officer ability. Operation couple hold interest.'),
(38, 19, 'zh', '新闻标题 19', 'Wrong but you religious long stock manager. Arrive special check respond summer various. Type simply task. Federal spring treatment city again hot.'),
(39, 20, 'en', 'News Title 20', 'Role war close arm. Never manage them while interest. Look middle your thousand. If pattern treat second. Reflect see each school week statement.'),
(40, 20, 'zh', '新闻标题 20', 'Low enter able piece hour. Upon where middle throw very.');

INSERT INTO ContentEditLog (log_id, user_id, post_id, action, content, log_time) VALUES
(1, 11, 1, 'Post', 'Initial post content', '2025-05-22 18:44:56'),
(2, 11, 2, 'Post', 'Initial post content', '2025-01-06 16:48:36'),
(3, 10, 3, 'Post', 'Initial post content', '2025-04-17 05:25:13'),
(4, 8, 4, 'Post', 'Initial post content', '2025-05-02 00:01:06'),
(5, 11, 5, 'Post', 'Initial post content', '2025-01-31 01:26:48'),
(6, 11, 6, 'Post', 'Initial post content', '2025-03-16 00:41:27'),
(7, 15, 7, 'Post', 'Initial post content', '2025-03-22 01:00:32'),
(8, 6, 8, 'Post', 'Initial post content', '2025-03-19 12:21:58'),
(9, 15, 9, 'Post', 'Initial post content', '2025-02-25 18:23:23'),
(10, 8, 10, 'Post', 'Initial post content', '2025-04-02 02:46:53'),
(11, 15, 11, 'Post', 'Initial post content', '2025-04-03 02:55:26'),
(12, 8, 12, 'Post', 'Initial post content', '2025-04-13 00:04:49'),
(13, 8, 13, 'Post', 'Initial post content', '2025-01-15 15:01:19'),
(14, 11, 14, 'Post', 'Initial post content', '2025-05-18 22:01:51'),
(15, 8, 15, 'Post', 'Initial post content', '2025-05-06 15:40:18'),
(16, 13, 16, 'Post', 'Initial post content', '2025-02-20 18:01:42'),
(17, 10, 17, 'Post', 'Initial post content', '2025-03-11 17:29:39'),
(18, 7, 18, 'Post', 'Initial post content', '2025-02-09 16:26:55'),
(19, 12, 19, 'Post', 'Initial post content', '2025-02-07 23:49:07'),
(20, 8, 20, 'Post', 'Initial post content', '2025-03-27 07:33:02');

INSERT INTO SchoolEditLog (log_id, user_id, school_id, action, log_time) VALUES
(1, 14, 1, 'Updated school info', '2025-01-28 12:15:15'),
(2, 13, 2, 'Updated school info', '2025-03-07 01:15:52'),
(3, 9, 3, 'Updated school info', '2025-01-19 01:53:57'),
(4, 13, 4, 'Updated school info', '2025-01-10 10:25:53'),
(5, 7, 5, 'Updated school info', '2025-01-08 18:08:11'),
(6, 13, 6, 'Updated school info', '2025-03-10 01:31:53'),
(7, 15, 7, 'Updated school info', '2025-02-20 10:47:18'),
(8, 12, 8, 'Updated school info', '2025-02-20 23:36:31'),
(9, 9, 9, 'Updated school info', '2025-03-24 22:12:50'),
(10, 13, 10, 'Updated school info', '2025-04-22 10:52:19'),
(11, 12, 11, 'Updated school info', '2025-04-07 14:35:13'),
(12, 7, 12, 'Updated school info', '2025-03-07 03:09:19'),
(13, 12, 13, 'Updated school info', '2025-04-15 01:10:03'),
(14, 6, 14, 'Updated school info', '2025-04-13 23:57:14'),
(15, 13, 15, 'Updated school info', '2025-03-12 15:08:12'),
(16, 11, 16, 'Updated school info', '2025-05-27 03:48:29'),
(17, 7, 17, 'Updated school info', '2025-01-17 00:05:53'),
(18, 7, 18, 'Updated school info', '2025-02-15 21:17:06'),
(19, 14, 19, 'Updated school info', '2025-05-23 18:50:03'),
(20, 10, 20, 'Updated school info', '2025-02-01 10:12:09');


INSERT INTO Kindergarten (sub_id, school_id, name, student_count) VALUES
(1, 1, 'KG 1', 65),
(1, 2, 'KG 2', 85),
(1, 3, 'KG 3', 50),
(1, 4, 'KG 4', 33),
(1, 5, 'KG 5', 74),
(1, 6, 'KG 6', 61),
(1, 7, 'KG 7', 45),
(1, 8, 'KG 8', 93),
(1, 9, 'KG 9', 92),
(1, 10, 'KG 10', 90),
(1, 11, 'KG 11', 53),
(1, 12, 'KG 12', 34),
(1, 13, 'KG 13', 44),
(1, 14, 'KG 14', 75),
(1, 15, 'KG 15', 70),
(1, 16, 'KG 16', 97),
(1, 17, 'KG 17', 81),
(1, 18, 'KG 18', 34),
(1, 19, 'KG 19', 97),
(1, 20, 'KG 20', 96);

INSERT INTO PrimarySchool (sub_id, school_id, name, student_count) VALUES
(1, 1, 'PS 1', 108),
(1, 2, 'PS 2', 200),
(1, 3, 'PS 3', 195),
(1, 4, 'PS 4', 110),
(1, 5, 'PS 5', 168),
(1, 6, 'PS 6', 139),
(1, 7, 'PS 7', 171),
(1, 8, 'PS 8', 156),
(1, 9, 'PS 9', 115),
(1, 10, 'PS 10', 190),
(1, 11, 'PS 11', 121),
(1, 12, 'PS 12', 174),
(1, 13, 'PS 13', 112),
(1, 14, 'PS 14', 200),
(1, 15, 'PS 15', 185),
(1, 16, 'PS 16', 127),
(1, 17, 'PS 17', 190),
(1, 18, 'PS 18', 107),
(1, 19, 'PS 19', 111),
(1, 20, 'PS 20', 115);

INSERT INTO JuniorHighSchool (sub_id, school_id, name, student_count) VALUES
(1, 1, 'JHS 1', 198),
(1, 2, 'JHS 2', 174),
(1, 3, 'JHS 3', 160),
(1, 4, 'JHS 4', 182),
(1, 5, 'JHS 5', 154),
(1, 6, 'JHS 6', 184),
(1, 7, 'JHS 7', 197),
(1, 8, 'JHS 8', 110),
(1, 9, 'JHS 9', 103),
(1, 10, 'JHS 10', 148),
(1, 11, 'JHS 11', 122),
(1, 12, 'JHS 12', 146),
(1, 13, 'JHS 13', 130),
(1, 14, 'JHS 14', 130),
(1, 15, 'JHS 15', 132),
(1, 16, 'JHS 16', 148),
(1, 17, 'JHS 17', 181),
(1, 18, 'JHS 18', 147),
(1, 19, 'JHS 19', 182),
(1, 20, 'JHS 20', 136);

INSERT INTO HighSchool (sub_id, school_id, name, student_count) VALUES
(1, 1, 'HS 1', 135),
(1, 2, 'HS 2', 177),
(1, 3, 'HS 3', 157),
(1, 4, 'HS 4', 154),
(1, 5, 'HS 5', 184),
(1, 6, 'HS 6', 174),
(1, 7, 'HS 7', 153),
(1, 8, 'HS 8', 176),
(1, 9, 'HS 9', 180),
(1, 10, 'HS 10', 149),
(1, 11, 'HS 11', 110),
(1, 12, 'HS 12', 193),
(1, 13, 'HS 13', 168),
(1, 14, 'HS 14', 175),
(1, 15, 'HS 15', 147),
(1, 16, 'HS 16', 153),
(1, 17, 'HS 17', 153),
(1, 18, 'HS 18', 136),
(1, 19, 'HS 19', 185),
(1, 20, 'HS 20', 110);

INSERT INTO AnonymousVisitLog (id, session_id, ip_address, school_id, action_type, visit_time) VALUES
(1, 'y8H6h8l7qgATtLFx', '53.244.205.244', 1, 'search', '2025-03-30 10:00:13'),
(2, 'lcBGYQ6TmA65MPh3', '167.186.16.157', 1, 'search', '2025-03-09 15:11:49'),
(3, 'BPFX7TOrPMf7otYj', '164.90.8.83', 2, 'view', '2025-04-12 17:20:15'),
(4, 'pD0ezNmREpOaUVgA', '68.238.183.36', 2, 'view', '2025-04-07 08:12:54'),
(5, '0rWEoBSou3ejxjnz', '62.229.40.211', 3, 'comment', '2025-05-17 19:13:46'),
(6, 'HzmA4KR1VxavU07z', '74.143.80.99', 3, 'search', '2025-04-28 22:18:18'),
(7, 'lquCu2r6AZDUd7ne', '131.17.200.97', 4, 'search', '2025-05-09 13:00:12'),
(8, 'cbp0MoDh6CpwL7SW', '65.67.114.255', 4, 'view', '2025-01-10 08:47:29'),
(9, 'Fv0Yg7NZRBT7qYHD', '109.41.126.26', 5, 'comment', '2025-04-26 21:39:50'),
(10, 'ZKtp5rBUJPuEuEvq', '83.70.30.221', 5, 'comment', '2025-04-06 06:07:59'),
(11, 'Iv9IvCtoStU6QlTr', '134.64.254.108', 6, 'search', '2025-03-24 14:55:27'),
(12, '8GrgmolaHr8IRh1E', '94.137.123.96', 6, 'view', '2025-02-15 03:35:18'),
(13, 'XnGBB19sMLT6mnOj', '104.43.60.148', 7, 'view', '2025-01-01 00:25:49'),
(14, 'IjzQDcrr1eoqXKXm', '10.46.73.98', 7, 'view', '2025-03-08 18:37:11'),
(15, 'TLboP1KbVYJVkGBr', '91.206.179.204', 8, 'search', '2025-05-16 12:18:44'),
(16, 'BY8DztgjzEPyVcfp', '72.161.184.254', 8, 'view', '2025-04-04 09:15:40'),
(17, 'Stazn0h6Oj5sRzDD', '148.65.89.62', 9, 'comment', '2025-02-20 10:06:12'),
(18, 'Ix5F21rWz5FYrsK9', '13.169.98.31', 9, 'comment', '2025-01-26 04:30:25'),
(19, '7h7ug0g4ai18eWqM', '189.120.246.198', 10, 'comment', '2025-03-10 12:42:03'),
(20, 'O001xtSV2ceN59UA', '203.203.108.20', 10, 'view', '2025-02-26 03:48:32'),
(21, 'Mo4iCppaX3QjBvKN', '104.176.153.252', 11, 'comment', '2025-01-11 11:47:12'),
(22, 'QCs90gxwsRbZya1W', '146.62.127.67', 11, 'view', '2025-02-10 16:45:32'),
(23, '4uzmW2wFqk467s1X', '88.12.167.185', 12, 'comment', '2025-01-18 04:11:55'),
(24, '7i71S87XwXaHCPPK', '81.126.56.83', 12, 'search', '2025-03-22 11:46:31'),
(25, 'CPU6zUjzgEz6cwB6', '100.195.225.52', 13, 'comment', '2025-01-10 05:30:43'),
(26, 'gQH8wylh0CPNLbWp', '57.186.208.236', 13, 'view', '2025-02-13 20:42:17'),
(27, 'kdTGUDWFgF6cW1GC', '24.85.62.252', 14, 'view', '2025-01-23 16:31:24'),
(28, 'dDyQE4efLerNHu9G', '40.47.11.232', 14, 'comment', '2025-04-07 22:29:24'),
(29, 'eZffTYIKIuhvPU1S', '40.209.67.156', 15, 'comment', '2025-01-24 21:08:40'),
(30, 'LvJnOng0wVJY08YM', '168.224.210.210', 15, 'search', '2025-03-22 17:32:04'),
(31, 'jtu6K2jUdfBALznF', '145.121.12.30', 16, 'comment', '2025-02-17 18:06:31'),
(32, 'ArQEPcyLasnipuaU', '148.149.184.157', 16, 'view', '2025-03-08 08:06:37'),
(33, 'z7k6CQwBgBye1UnW', '37.0.142.164', 17, 'view', '2025-02-23 16:14:01'),
(34, 'FhF4vTYYojmLVOkV', '211.38.42.222', 17, 'comment', '2025-01-24 00:39:34'),
(35, 'MFCIX3BYOtDjdg3v', '14.209.224.215', 18, 'search', '2025-05-21 18:41:38'),
(36, 'fOcR9GLw4yWQdNuu', '21.64.201.250', 18, 'search', '2025-05-21 03:14:36'),
(37, 'wwln6Eoie0gVZ2cu', '151.46.181.4', 19, 'search', '2025-05-21 23:12:25'),
(38, 'ixkZVYkBzPoBrUBH', '211.67.40.28', 19, 'comment', '2025-05-12 17:11:24'),
(39, 'BFZf4Y25zyxxfntg', '91.198.0.208', 20, 'search', '2025-01-02 03:04:39'),
(40, 'OXirZRiRBaepZITG', '44.179.164.246', 20, 'view', '2025-01-22 11:44:21');

INSERT INTO VisitLog (log_id, user_id, school_id, visit_time, action_type) VALUES
(1, 20, 1, '2025-04-03 11:04:41', 'comment'),
(2, 28, 2, '2025-03-30 09:22:31', 'comment'),
(3, 27, 3, '2025-03-26 07:31:13', 'comment'),
(4, 20, 4, '2025-05-14 22:28:00', 'view'),
(5, 30, 5, '2025-04-22 04:52:05', 'comment'),
(6, 25, 6, '2025-01-17 06:37:05', 'edit'),
(7, 24, 7, '2025-02-25 16:24:32', 'view'),
(8, 28, 8, '2025-04-19 14:30:32', 'edit'),
(9, 29, 9, '2025-04-30 06:47:55', 'view'),
(10, 28, 10, '2025-02-02 12:38:40', 'comment'),
(11, 30, 11, '2025-03-26 09:43:00', 'comment'),
(12, 21, 12, '2025-02-03 23:03:37', 'view'),
(13, 28, 13, '2025-05-02 06:43:04', 'comment'),
(14, 24, 14, '2025-02-24 13:33:28', 'comment'),
(15, 24, 15, '2025-01-02 06:42:01', 'view'),
(16, 18, 16, '2025-02-10 21:34:42', 'edit'),
(17, 23, 17, '2025-01-14 20:30:32', 'comment'),
(18, 26, 18, '2025-02-08 08:35:08', 'edit'),
(19, 28, 19, '2025-01-29 15:53:28', 'edit'),
(20, 28, 20, '2025-02-06 19:26:47', 'edit');

Commit;